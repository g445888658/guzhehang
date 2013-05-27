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
using System.Threading;
using System.Net.Sockets;
using ValueHelper.Infrastructure;
using ValueHelper.ValueSocket.SocketEvents;
using ValueHelper.ValueSocket.Infrastructure;

namespace ValueHelper.ValueSocket.SocketBase
{
    public class ServerBase : IDisposable
    {
        protected Socket Server;
        protected IPEndPoint localEndPoint;
        protected event ReceiveHandler OnReceive;
        protected event AcceptHandler OnAccept;

        private Int32 connectNumber;
        private Int32 bufferSize = 1024;
        private BufferManager bufferManager;
        private SocketAsyncEventArgsPool readWritePool;
        private Int32 totalBytesRead;
        private Int32 connectSocketNumber;
        private Semaphore acceptClientMaxNumber;

        public ServerBase(ServerSetting setting)
        {
            try
            {
                Server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                localEndPoint = new IPEndPoint(IPAddress.Parse(setting.IPAddress), setting.Port);

                this.bufferSize = setting.BufferSize;
                this.connectNumber = setting.ConnectNumber;

                this.Initialize();
            }
            catch
            {
                throw new InvalidOperationException("IP地址端口设置失败,请检查配置是否正确");
            }
        }

        private void Initialize()
        {
            this.totalBytesRead = 0;
            this.connectSocketNumber = 0;
            this.bufferManager = new BufferManager(bufferSize * connectNumber * 2, bufferSize);
            this.readWritePool = new SocketAsyncEventArgsPool(connectNumber);
            this.acceptClientMaxNumber = new Semaphore(connectNumber, connectNumber);

            bufferManager.InitBuffer();
            SocketAsyncEventArgs readWriteEventArgs;
            for (int index = 0; index < connectNumber; index++)
            {
                readWriteEventArgs = new SocketAsyncEventArgs();
                readWriteEventArgs.UserToken = new AsyncUserToken();
                readWriteEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(IO_Completed);
                bufferManager.SetBuffer(readWriteEventArgs);
                readWritePool.Push(readWriteEventArgs);
            }

        }

        private void IO_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.SocketError == SocketError.Success)
            {
                switch (e.LastOperation)
                {
                    case SocketAsyncOperation.Receive:
                        ProcessReceive(e);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        ///  开始捕捉客户连接
        /// </summary>
        /// <param name="acceptEventArgs"></param>
        protected void StartAccept(SocketAsyncEventArgs acceptEventArgs)
        {
            // 如果接受事件为null 实例化一个
            if (acceptEventArgs == null)
            {
                acceptEventArgs = new SocketAsyncEventArgs();
                acceptEventArgs.Completed += new EventHandler<SocketAsyncEventArgs>(acceptEventArgs_Completed);
            }
            else
            {
                acceptEventArgs.AcceptSocket = null;
            }

            acceptClientMaxNumber.WaitOne();
            Boolean willRaiseEvent = Server.AcceptAsync(acceptEventArgs);
            if (!willRaiseEvent)
                ProcessAccept(acceptEventArgs);
        }

        /// <summary>
        ///  异步事件完成时调用该方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acceptEventArgs_Completed(object sender, SocketAsyncEventArgs e)
        {
            this.ProcessAccept(e);
        }

        protected Boolean Send(Socket socket, Byte[] data, Int32 size, Int32 timeout)
        {
            socket.SendTimeout = 0;
            Int32 startTickCount = Environment.TickCount;
            Int32 sent = 0;
            do
            {
                if (Environment.TickCount > startTickCount + timeout)
                    return false;

                try
                {
                    sent += socket.Send(data, sent, size - sent, SocketFlags.None);
                }
                catch (SocketException ex)
                {
                    if (ex.SocketErrorCode == SocketError.WouldBlock ||
                        ex.SocketErrorCode == SocketError.IOPending ||
                        ex.SocketErrorCode == SocketError.NoBufferSpaceAvailable)
                    {
                        Thread.Sleep(30);
                    }
                    else
                        return false;
                }
            } while (sent < size);
            return true;
        }

        /// <summary>
        ///  将捕捉到Socket Async事件移交readWritePool集中控制
        /// </summary>
        /// <param name="acceptEventArgs"></param>
        private void ProcessAccept(SocketAsyncEventArgs acceptEventArgs)
        {
            // 多线程共享变量 递增
            Interlocked.Increment(ref connectSocketNumber);

            // 从堆栈中弹出一个事件执受连接
            SocketAsyncEventArgs readEventArgs = readWritePool.Pop();
            ((AsyncUserToken)readEventArgs.UserToken).Socket = acceptEventArgs.AcceptSocket;

            if (OnAccept != null)
            {
                OnAccept(new SocketEventArgs(acceptEventArgs.AcceptSocket));
            }

            // 接受到的连接执行接收操作
            Boolean willRaiseEvent = acceptEventArgs.AcceptSocket.ReceiveAsync(readEventArgs);
            if (!willRaiseEvent)
                ProcessAccept(readEventArgs);
            StartAccept(acceptEventArgs);
        }

        /// <summary>
        ///  异步接收数据的处理程序
        /// </summary>
        /// <param name="receiveEventArgs"></param>
        private void ProcessReceive(SocketAsyncEventArgs receiveEventArgs)
        {
            AsyncUserToken token = (AsyncUserToken)receiveEventArgs.UserToken;
            if (receiveEventArgs.BytesTransferred > 0 && receiveEventArgs.SocketError == SocketError.Success)
            {
                Interlocked.Add(ref totalBytesRead, receiveEventArgs.BytesTransferred);
            }
            Int32 readedLength = receiveEventArgs.BytesTransferred;

            // 判断客户端连接是否断开
            // 断开返回true
            if (!token.Socket.Poll(10, SelectMode.SelectRead) || readedLength != 0)
            {
                Byte[] buffer = new Byte[readedLength];
                Buffer.BlockCopy(receiveEventArgs.Buffer, receiveEventArgs.Offset, buffer, 0, readedLength);

                if (OnReceive != null)
                    OnReceive(new ReceiveEventArgs(token.Socket) { Data = buffer });

                Boolean willRaiseEvent = token.Socket.ReceiveAsync(receiveEventArgs);
                if (!willRaiseEvent)
                    CloseClientSocket(receiveEventArgs);
            }
            // 如果客户端已经断开,那么取消完成事件的委托
            // 将事件重新压回堆栈
            else
            {
                this.CloseClientSocket(receiveEventArgs);
            }
        }

        /// <summary>
        ///  操作失败时调用这个方法
        ///  回收AsyncEvent并开始捕捉新连接
        /// </summary>
        /// <param name="e"></param>
        private void CloseClientSocket(SocketAsyncEventArgs e)
        {
            AsyncUserToken token = (AsyncUserToken)e.UserToken;

            try
            {
                token.Socket.Shutdown(SocketShutdown.Send);
            }
            catch (Exception) { }

            token.Socket.Close();
            Interlocked.Decrement(ref connectSocketNumber);
            acceptClientMaxNumber.Release();

            e.UserToken = new AsyncUserToken();
            readWritePool.Push(e);

            StartAccept(null);
        }

        #region IDisposable 成员

        private Boolean disposed = false;
        private void Dispose(Boolean disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    bufferManager.Dispose();
                    readWritePool.Dispose();
                    acceptClientMaxNumber.Close();
                    Server.Shutdown(SocketShutdown.Both);
                    Server.Close();
                    disposed = true;
                }
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
