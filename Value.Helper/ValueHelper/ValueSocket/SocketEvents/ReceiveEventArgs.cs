using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using ValueHelper.ValueSocket.Infrastructure;

namespace ValueHelper.ValueSocket.SocketEvents
{
    public class ReceiveEventArgs : SocketEventArgs
    {
        public ReceiveEventArgs(Socket socket)
            : base(socket) { }

        public Byte[] Data { get; set; }
    }
}
