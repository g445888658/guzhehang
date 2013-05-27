using System;
using System.Net.Sockets;
using ValueHelper.Infrastructure;

namespace ValueHelper.ValueSocket.Infrastructure
{
    public class BufferManager
    {
        // 当前缓存管理器的管理的总字节长度
        Int32 totalBytes;
        // 管理的字节数组
        Byte[] buffer;
        ValueStack<Int32> freeIndexPool;
        Int32 currentIndex;
        // 操作时的字节大小
        Int32 bufferSize;

        public BufferManager(Int32 totalBytes, Int32 bufferSize)
        {
            this.totalBytes = totalBytes;
            this.currentIndex = 0;
            this.bufferSize = bufferSize;
            this.freeIndexPool = new ValueStack<int>();
        }

        /// <summary>
        ///  初始化管理的字节数组
        /// </summary>
        public void InitBuffer()
        {
            buffer = new Byte[totalBytes];
        }

        /// <summary>
        ///  设置Async事件的缓冲数据
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Boolean SetBuffer(SocketAsyncEventArgs args)
        {
            // 如果缓冲数据不为空那么在断点处添加缓冲数据
            if (!freeIndexPool.Empty())
            {
                args.SetBuffer(buffer, freeIndexPool.Pop(), bufferSize);
            }
            else
            {
                // 如果管理的总字节长度减去操作时要用的字节长度
                // 小于当前字节索引
                if ((totalBytes - bufferSize) < currentIndex)
                    return false;
                args.SetBuffer(buffer, currentIndex, bufferSize);
                currentIndex += bufferSize;
            }
            return true;
        }

        /// <summary>
        ///  释放Async事件中的缓冲
        ///  将缓冲重新释放到缓冲池中
        /// </summary>
        /// <param name="args"></param>
        public void FreeBuffer(SocketAsyncEventArgs args)
        {
            freeIndexPool.Push(args.Offset);
            args.SetBuffer(null, 0, 0);
        }

        public void Dispose()
        {
            buffer = null;
            freeIndexPool.Dispose();
        }
    }
}
