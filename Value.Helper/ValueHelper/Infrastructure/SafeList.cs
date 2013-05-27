using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ValueHelper.Infrastructure
{
    /// <summary>
    ///  该类型所有方法都是加锁的
    /// </summary>
    /// <typeparam name="T">调用SafeList[String]需重写ToString方法</typeparam>
    public class SafeList<T>
    {
        private List<T> list;
        private static Object safeLock = new Object();
        private Int32 count;
        public Int32 Count { get { return count; } }

        public SafeList()
        {
            list = new List<T>();
            count = 0;
        }

        public void Add(T value)
        {
            lock (safeLock)
            {
                list.Add(value);
                count++;
            }
        }

        public void Remove(T value)
        {
            lock (safeLock)
            {
                list.Remove(value);
                count--;
            }
        }

        public void RemoveAt(Int32 index)
        {
            lock (safeLock)
            {
                list.RemoveAt(index);
                count--;
            }
        }

        public void Clear()
        {
            lock (this)
            {
                this.list.Clear();
                count = 0;
            }
        }

        public T this[Int32 index]
        {
            get
            {
                lock (safeLock)
                { return list[index]; }
            }
        }

        public T this[String name]
        {
            get
            {
                lock (safeLock)
                {
                    foreach (T item in list)
                    {
                        if (item.ToString() == name)
                            return item;
                    }
                    return default(T);
                }
            }
        }

        public void ForEach(Action<T> action)
        {
            lock (safeLock)
            {
                foreach (T item in list)
                {
                    action(item);
                }
            }
        }
    }
}
