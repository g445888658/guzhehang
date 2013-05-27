using System;
using ValueHelper.Infrastructure;
using System.Net.Sockets;

namespace ValueHelper.ValueSocket.Infrastructure
{
    public class SocketAsyncEventArgsPool : ValueStack<SocketAsyncEventArgs>
    {
        private Int32 capacity;
        private Object poolock = new Object();

        public SocketAsyncEventArgsPool(Int32 capacity)
        {
            this.capacity = capacity;
        }

        public override void Push(SocketAsyncEventArgs data)
        {
            lock (poolock)
            {
                base.Push(data);
            }
        }

        public override SocketAsyncEventArgs Pop()
        {
            lock (poolock)
            {
                return base.Pop();
            }
        }
    }
}
