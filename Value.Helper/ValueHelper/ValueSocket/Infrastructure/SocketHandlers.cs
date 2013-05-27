using System;
using ValueHelper.ValueSocket.SocketEvents;

namespace ValueHelper.ValueSocket.Infrastructure
{
    public delegate void ReceiveHandler(ReceiveEventArgs e);

    public delegate void AcceptHandler(SocketEventArgs e);
}
