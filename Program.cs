using Net.Event;
using System;
using ThreeIII3Server;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NDebug.BindConsoleLog(); //绑定控制台日志
            NDebug.WriteFileMode = WriteLogMode.All; //开启日志文件记录模式
            var service = new Service(); //创建服务器实例
            service.Start(9543); //开始启动服务器, 端口9543
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}