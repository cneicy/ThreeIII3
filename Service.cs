using Net.Event;
using Net.Server;
using Net.Share;
using System.Numerics;

namespace ThreeIII3Server
{
    public class Service : TcpServer<Player, Scene>
    {
        [Rpc(cmd = NetCmd.SafeCall)]
        private void HelloWorld(Player client, string msg)
        {
            NDebug.Log(msg);
            SendRT(client, "HelloWorldCall", "你好, 我是服务器!");
        }
    }
}