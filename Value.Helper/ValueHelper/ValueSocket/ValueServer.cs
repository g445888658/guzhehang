using System;
using System.Text;
using System.Net.Sockets;
using ValueHelper.Infrastructure;
using ValueHelper.ValueSocket.SocketBase;
using ValueHelper.ValueSocket.SocketEvents;
using ValueHelper.ValueSocket.Infrastructure;

namespace ValueHelper.ValueSocket
{
    public class ValueServer : ServerBase
    {
        private Encoding encoding;
        private const Int32 sendTimeout = 10000;

        public event ReceiveHandler OnReceive;
        public event AcceptHandler OnAccept;

        public ValueServer(String ipAddress, Int32 port, Encoding encoding)
            : base(new ServerSetting { IPAddress = ipAddress, Port = port, ConnectNumber = 1000, BufferSize = 1024 })
        {
            this.encoding = encoding;
        }

        public void Start()
        {
            base.OnReceive += new ReceiveHandler(ValueServer_OnBaseReceive);
            base.OnAccept += new AcceptHandler(ValueServer_OnAccept);

            Server.Bind(base.localEndPoint);
            Server.Listen(100);
            base.StartAccept(null);
        }

        public Boolean Send(Socket socket, String msg)
        {
            Byte[] data = encoding.GetBytes(msg);
            return Send(socket, data, data.Length, sendTimeout);
        }

        public Boolean Send(Socket socket, Byte[] data)
        {
            return Send(socket, data, data.Length, sendTimeout);
        }

        private void ValueServer_OnBaseReceive(SocketEvents.ReceiveEventArgs e)
        {
            if (OnReceive != null)
                OnReceive(e);
        }


        private void ValueServer_OnAccept(SocketEventArgs e)
        {
            if (OnAccept != null)
                OnAccept(e);
        }

        public new void Dispose()
        {
            OnReceive -= new ReceiveHandler(ValueServer_OnBaseReceive);
            base.Dispose();
        }
    }
}
