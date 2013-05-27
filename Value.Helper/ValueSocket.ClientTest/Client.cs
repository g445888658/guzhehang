using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueHelper.ValueSocket;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ValueSocket.ClientTest
{
    class Client
    {
        static void Main(string[] args)
        {
            ValueClient client = new ValueClient("127.0.0.1", 3000, Encoding.UTF8);
            client.OnReceive += new ValueHelper.ValueSocket.Infrastructure.ReceiveHandler(client_OnReceive);
            ManualResetEvent connectDone = new ManualResetEvent(false);
            client.Connect(connectDone);
            connectDone.WaitOne();
            client.Send("I'm Test Packet");
            client.Receive();
            Thread.Sleep(10000);
            client.Send("I'm Test Packet too");
            //client.Close();

            Console.Read();
        }

        static void client_OnReceive(ValueHelper.ValueSocket.SocketEvents.ReceiveEventArgs e)
        {
            Console.WriteLine(Encoding.UTF8.GetString(e.Data)); ;
        }
    }
}
