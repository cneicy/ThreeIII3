﻿namespace Net.Server
{
    using Net.Share;
    using global::System;
    using global::System.Net;
    using global::System.Net.Sockets;
    using global::System.Threading;
    using Debug = Event.NDebug;
    using Net.System;
    using global::System.Security.Cryptography;
    using Net.Helper;

    /// <summary>
    /// TCP服务器类型
    /// 第三版本 2020.9.14
    /// <para>Player:当有客户端连接服务器就会创建一个Player对象出来, Player对象和XXXClient是对等端, 每当有数据处理都会通知Player对象. </para>
    /// <para>Scene:你可以定义自己的场景类型, 比如帧同步场景处理, mmorpg场景什么处理, 可以重写Scene的Update等等方法实现每个场景的更新和处理. </para>
    /// </summary>
    public class TcpServer<Player, Scene> : ServerBase<Player, Scene> where Player : NetPlayer, new() where Scene : NetScene<Player>, new()
    {
        /// <summary>
        /// tcp数据长度(4) + 1CRC协议 = 5
        /// </summary>
        protected override byte frame { get; set; } = 5;
        public override bool MD5CRC
        {
            get => md5crc;
            set
            {
                md5crc = value;
                frame = (byte)(value ? 5 + 16 : 5);
            }
        }
        public override int HeartInterval { get; set; } = 1000 * 60 * 10;//10分钟跳一次
        public override byte HeartLimit { get; set; } = 2;//确认两次
        
        protected override void CreateOtherThread()
        {
            var thread = new Thread(ProcessAcceptConnect) { IsBackground = true, Name = "ProcessAcceptConnect" };
            thread.Start();
            threads.Add("ProcessAcceptConnect", thread);
        }

        protected override void CreateServerSocket(ushort port)
        {
            var ip = new IPEndPoint(IPAddress.Any, port);
            Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Server.NoDelay = true;
            Server.Bind(ip);
            Server.Listen(LineUp);
        }

        protected override void StartSocketHandler()
        {
        }

        private void ProcessAcceptConnect()
        {
            var acceptList = new FastList<Socket>();
            while (IsRunServer)
            {
                try
                {
                    if (Server.Poll(0, SelectMode.SelectRead))
                    {
                        var socket = Server.Accept();
                        socket.ReceiveTimeout = 10000;
                        acceptList.Add(socket);
                    }
                    else Thread.Sleep(1);
                    CheckAcceptList(acceptList);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"接受异常:{ex}");
                }
            }
        }

        private void CheckAcceptList(FastList<Socket> acceptList)
        {
            Socket client;
            for (int i = 0; i < acceptList.Count; i++)
            {
                client = acceptList[i];
                if (!client.Connected)
                {
                    client.Close();
                    acceptList.RemoveAt(i);
                    continue;
                }
                if (client.Poll(0, SelectMode.SelectRead))
                {
                    using (var segment = BufferPool.Take())
                    {
                        segment.Count = client.Receive(segment, 0, segment.Length, SocketFlags.None, out var error);
                        if (segment.Count == 0 | error != SocketError.Success) //当等待10秒超时
                        {
                            client.Close();
                            acceptList.RemoveAt(i);
                            continue;
                        }
                        client.ReceiveTimeout = 0;
                        var userID = segment.ReadInt32();
                        if (!UIDClients.TryGetValue(userID, out var client1))
                        {
                            client1 = AcceptHander(client, client.RemoteEndPoint);
                            goto J;
                        }
                        if (!client1.Client.Connected) //防止出错或者假冒的客户端设置, 导致直接替换真实的客户端
                        {
                            client1.Client = client;
                            SetClientIdentity(client1);
                            client1.OnReconnecting();
                            OnReconnecting(client1);
                        }
                        else AcceptHander(client, client.RemoteEndPoint);//如果取出的客户端不断线, 那说明是客户端有问题或者错乱, 给他个新的连接
                        J: acceptList.RemoveAt(i);
                    }
                }
            }
        }

        protected override void OnThreadQueueSet(Player client)
        {
            var value = threadNum++;
            client.Group = ThreadGroups[value % ThreadGroups.Count];
        }

        protected override void OnSceneGroupSet(Scene scene)
        {
            var value = threadNum++;
            scene.Group = ThreadGroups[value % ThreadGroups.Count];
        }

        protected override void ResolveDataQueue(Player client, ref bool isSleep, uint tick)
        {
            if (!client.Client.Connected) //当socket断开后, 需要重连, 所以会等待一段重连时间
            {
                if (tick >= client.ReconnectTimeout)
                    RemoveClient(client);
                return;
            }
            if (client.Client.Poll(0, SelectMode.SelectRead))
            {
                var segment = BufferPool.Take();
                segment.Count = client.Client.Receive(segment, 0, segment.Length, SocketFlags.None, out SocketError error);
                if (segment.Count == 0 | error != SocketError.Success)
                {
                    BufferPool.Push(segment);
                    client.Client.Disconnect(false);//标记为断开状态
                    client.ReconnectTimeout = tick + ReconnectionTimeout;
                    client.OnConnectLost();
                    OnConnectLost(client);
                    return;
                }
                receiveCount += segment.Count;
                receiveAmount++;
                ResolveBuffer(client, ref segment);
                BufferPool.Push(segment);
                isSleep = false;
            }
        }

        protected override void ReceiveProcessed(EndPoint remotePoint, ref bool isSleep)
        {
        }

        protected override bool IsInternalCommand(Player client, RPCModel model)
        {
            if (model.cmd == NetCmd.Connect | model.cmd == NetCmd.Broadcast)
                return true;
            return false;
        }

        protected override byte[] PackData(Segment stream)
        {
            stream.Flush();
            if (MD5CRC)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                var head = frame;
                byte[] retVal = md5.ComputeHash(stream, head, stream.Count - head);
                EncryptHelper.ToEncrypt(Password, retVal);
                int len = stream.Count - head;
                var lenBytes = BitConverter.GetBytes(len);
                byte crc = CRCHelper.CRC8(lenBytes, 0, lenBytes.Length);
                stream.Position = 0;
                stream.Write(lenBytes, 0, 4);
                stream.WriteByte(crc);
                stream.Write(retVal, 0, retVal.Length);
                stream.Position = len + head;
            }
            else
            {
                int len = stream.Count - frame;
                var lenBytes = BitConverter.GetBytes(len);
                byte crc = CRCHelper.CRC8(lenBytes, 0, lenBytes.Length);
                stream.Position = 0;
                stream.Write(lenBytes, 0, 4);
                stream.WriteByte(crc);
                stream.Position = len + frame;
            }
            return stream.ToArray();
        }

        protected override void SendRTDataHandle(Player client, QueueSafe<RPCModel> rtRPCModels)
        {
            SendDataHandle(client, rtRPCModels, true);
        }
#if TEST1
        ListSafe<byte> list = new ListSafe<byte>();
#endif
        protected override void SendByteData(Player client, byte[] buffer, bool reliable)
        {
            if (!client.Client.Connected)
                return;
            if (buffer.Length <= frame)//解决长度==6的问题(没有数据)
                return;
            if (client.Client.Poll(1, SelectMode.SelectWrite))
            {
#if TEST1
                list.AddRange(buffer);
                do 
                {
                    var buffer1 = list.GetRemoveRange(0, RandomHelper.Range(0, buffer.Length));
                    Net.Client.ClientBase.Instance.ReceiveTest(buffer1);
                }
                while (client.tcpRPCModels.Count == 0 & list.Count > 0);
#else
                int count1 = client.Client.Send(buffer, 0, buffer.Length, SocketFlags.None, out SocketError error);
                if (error != SocketError.Success | count1 <= 0)
                {
                    OnSendErrorHandle?.Invoke(client, buffer, true);
                    return;
                }
                else if (count1 != buffer.Length)
                    Debug.Log($"发送了{buffer.Length - count1}个字节失败!");
                sendAmount++;
                sendCount += buffer.Length;
#endif
            }
            else
            {
                Debug.LogError($"[{client}]发送缓冲列表已经超出限制!");
            }
        }

        protected override void CheckHeart(Player client, uint tick)
        {
            if (!client.Client.Connected)
            {
                if (tick >= client.ReconnectTimeout)
                    RemoveClient(client);
                return;
            }
            if (client.heart > HeartLimit * 5)
            {
                client.Redundant = true;
                RemoveClient(client);
                return;
            }
            client.heart++;
            if (client.heart <= HeartLimit)//确认心跳包
                return;
            SendRT(client, NetCmd.SendHeartbeat, new byte[0]);//保活连接状态
        }
    }

    /// <summary>
    /// 默认tcp服务器，当不需要处理Player对象和Scene对象时可使用
    /// </summary>
    public class TcpServer : TcpServer<NetPlayer, DefaultScene>
    {
    }
}