using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueHelper.ValueSocket;
using ValueHelper.ValueSocket.Infrastructure;
using System.Net;

namespace ValueSocket.ServerTest
{
    class Server
    {

        static ValueServer server;
        static void Main(string[] args)
        {
            server = new ValueServer("127.0.0.1", 3000, Encoding.UTF8);
            server.Start();
            server.OnReceive += new ReceiveHandler(server_OnReceive);
            server.OnAccept += new AcceptHandler(server_OnAccept);

            //ValueHelper.ValueSocket.Server asd = new ValueHelper.ValueSocket.Server(1000, 1024);
            //asd.Init();
            //asd.Start(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 3000));
            Console.ReadLine();
        }

        static void server_OnAccept(ValueHelper.ValueSocket.SocketEvents.SocketEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private static void server_OnReceive(ValueHelper.ValueSocket.SocketEvents.ReceiveEventArgs e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e.Data));


            Boolean result = server.Send(e.Socket, e.Data);
            if (!result)
                Console.WriteLine("失败");
        }
    }
}
