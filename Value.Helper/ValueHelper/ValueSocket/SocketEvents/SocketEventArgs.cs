using System;
using System.Net.Sockets;
using ValueHelper.ValueSocket.Infrastructure;

namespace ValueHelper.ValueSocket.SocketEvents
{
    public class SocketEventArgs : EventArgs
    {
        public Socket Socket { get; private set; }

        public SocketEventArgs(Socket socket)
        {
            this.Socket = socket;

        }
    }
}
