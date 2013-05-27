/*
  >>>------ Copyright (c) 2012 zformular ----> 
 |                                            |
 |            Author: zformular               |
 |        E-mail: zformular@163.com           |
 |             Date: 10.17.2012               |
 |                                            |
 ╰==========================================╯
 
*/

using System;
using System.Net;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using ValueHelper.ValueSocket.Infrastructure;
using ValueHelper.ValueSocket.SocketEvents;

namespace ValueHelper.ValueSocket
{
    public class ValueClient
    {
        private Encoding encoding;
        private Socket client;
        private IPEndPoint remoteEndPoint;

        public event ReceiveHandler OnReceive;

        public ValueClient(String ipAddress, Int32 port, Encoding encoding)
        {
            try
            {
                client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                remoteEndPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

                this.encoding = encoding;
            }
            catch
            {
                throw new InvalidOperationException("IP地址端口设置失败,请检查配置是否正确");
            }
        }

        public void Connect(ManualResetEvent connectDone)
        {
            client.BeginConnect(remoteEndPoint, ConnectCallback, connectDone);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            client.EndConnect(ar);
            ((ManualResetEvent)ar.AsyncState).Set();
        }

        public void Send(String msg)
        {
            Byte[] data = encoding.GetBytes(msg);
            ClientState state = new ClientState();
            state.InitData(data);
            client.BeginSend(data, 0, data.Length, 0, SendCallback, state);
        }

        private void Send(ClientState state)
        {
            if (client.Connected)
            {
                client.BeginSend(state.Data, state.usered, state.remaining, 0, SendCallback, state);
            }
        }

        private void SendCallback(IAsyncResult ar)
        {
            if (client.Connected)
            {
                ClientState state = (ClientState)ar.AsyncState;
                Int32 sendLength = client.EndSend(ar);
                if (sendLength < state.totalLength)
                {
                    state.remaining = state.totalLength - sendLength;
                    state.usered = sendLength;

                    this.Send(state);
                }
            }
        }

        public void Receive()
        {
            if (client.Connected)
            {
                ClientState state = new ClientState();
                state.InitData(1024);
                client.BeginReceive(state.Data, state.usered, state.remaining, 0, ReceiveCallback, state);
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            if (client.Connected)
            {
                ClientState state = (ClientState)ar.AsyncState;
                Int32 received = client.EndReceive(ar);
                Byte[] buffer = new Byte[received];
                Buffer.BlockCopy(state.Data, 0, buffer, 0, received);
                if (OnReceive != null)
                {
                    OnReceive(new ReceiveEventArgs(client) { Data = buffer });
                }
                this.Receive();
            }
        }

        private void ProcessConnect(SocketAsyncEventArgs connectEventArgs)
        {
            if (connectEventArgs.SocketError == SocketError.Success)
            {
                Boolean willRaiseEvent = client.ReceiveAsync(connectEventArgs);
                if (!willRaiseEvent)
                    ProcessReceive(connectEventArgs);
            }
        }

        private void ProcessReceive(SocketAsyncEventArgs receiveEventArgs)
        {
            Int32 readedLength = receiveEventArgs.BytesTransferred;
            if (client.Poll(10, SelectMode.SelectRead))
            {
                Byte[] buffer = new Byte[readedLength];
                Buffer.BlockCopy(receiveEventArgs.Buffer, receiveEventArgs.Offset, buffer, 0, readedLength);

                Boolean willRaiseEvent = client.ReceiveAsync(receiveEventArgs);
                if (!willRaiseEvent)
                    ProcessConnect(receiveEventArgs);
            }
        }

        public void Close()
        {
            client.Shutdown(SocketShutdown.Send);
            client.Close();
        }


    }
}
