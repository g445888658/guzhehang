using System;
using System.Net.Sockets;

namespace ValueHelper.ValueSocket.Infrastructure
{
    public class ClientState
    {
        public Socket Client;
        public Byte[] Data;
        public Int32 usered;
        public Int32 remaining;
        public Int32 totalLength;

        public void InitData(Int32 length)
        {
            this.Data = new Byte[length];
            this.totalLength = length;
            this.remaining = length;
            this.usered = 0;
        }

        public void InitData(Byte[] data)
        {
            this.Data = data;
            this.totalLength = data.Length;
            this.remaining = data.Length;
            this.usered = 0;
        }
    }
}
