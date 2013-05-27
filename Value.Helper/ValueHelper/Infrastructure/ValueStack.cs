using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueHelper.Infrastructure
{
    public class ValueStack<T> : IDisposable
    {
        public Int32 Count { get; private set; }
        private Entry<T> top = null;

        public virtual void Push(T data)
        {
            top = new Entry<T>(top, data);
            Count++;
        }

        public virtual T Pop()
        {
            if (top != null)
            {
                Count--;
                T result = top.Data;
                top = top.Next;
                return result;
            }
            throw new InvalidOperationException();
        }

        public Boolean Empty()
        {
            return Count == 0;
        }

        private class Entry<M>
        {
            public Entry<M> Next;
            public M Data;
            public Entry(Entry<M> next, M data)
            {
                this.Next = next;
                this.Data = data;
            }
        }

        public void Dispose()
        {
            while (Count > 0)
            {
                Pop();
            }
        }
    }


}
