using System;
using System.Text;

namespace ValueHelper.ValueSocket.Infrastructure
{
    public class ServerSetting
    {
        public String IPAddress { get; set; }

        public Int32 Port { get; set; }

        public Int32 ConnectNumber { get; set; }

        public Int32 BufferSize { get; set; }
    }
}
