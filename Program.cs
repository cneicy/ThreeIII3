using Net.Event;
using System;
using ThreeIII3Server;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NDebug.BindConsoleLog();
            NDebug.WriteFileMode = WriteLogMode.All;
            var service = new Service();
            service.Start(9543);
            while (true)
            {
                Console.ReadLine();
            }
        }
    }
}