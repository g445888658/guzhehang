/*
  >>>------ Copyright (c) 2012 zformular ----> 
 |                                            |
 |            Author: zformular               |
 |        E-mail: zformular@163.com           |
 |             Date: 10.9.2012                |
 |                                            |
 ╰==========================================╯
 
*/

using System;
using System.Collections.Generic;
using System.Collections;

namespace ValueHelper.Infrastructure
{
    public class KeyvalList<TKey, TValue> : IEnumerable
    {
        private List<Keyval<TKey, TValue>> keyvalList;

        public KeyvalList()
        {
            keyvalList = new List<Keyval<TKey, TValue>>();
        }

        public Int32 Count { get { return keyvalList.Count; } }

        public Keyval<TKey, TValue> this[Int32 index]
        {
            get
            {
                if (index >= keyvalList.Count)
                    throw new InvalidOperationException("索引值必须消息集合个数");

                return keyvalList[index];
            }
            set
            {
                if (index >= keyvalList.Count)
                    throw new InvalidOperationException("索引值必须消息集合个数");

                keyvalList[index] = value;
            }
        }

        public TValue this[String key]
        {
            get
            {
                for (int i = 0; i < keyvalList.Count; i++)
                {
                    if (key == keyvalList[i].Key.ToString())
                        return keyvalList[i].Value;
                }
                throw new InvalidOperationException("不存在键 " + key);
            }
            set
            {
                for (int i = 0; i < keyvalList.Count; i++)
                {
                    if (key == keyvalList[i].Key.ToString())
                    {
                        keyvalList[i].Value = value;
                        return;
                    }
                }
                throw new InvalidOperationException("不存在键 " + key);

            }
        }

        public void Add(TKey key, TValue value)
        {
            this.keyvalList.Add(new Keyval<TKey, TValue> { Key = key, Value = value });
        }

        public void Add(Keyval<TKey, TValue> keyval)
        {
            this.keyvalList.Add(keyval);
        }

        public void AddRange(IEnumerable<Keyval<TKey, TValue>> keyvals)
        {
            this.keyvalList.AddRange(keyvals);
        }

        public List<Keyval<TKey, TValue>> ToList()
        {
            return keyvalList;
        }

        public void Remove(Keyval<TKey, TValue> keyval)
        {
            this.keyvalList.Remove(keyval);
        }

        public void Remove(String key)
        {
            Keyval<TKey, TValue> target = null;
            foreach (var item in keyvalList)
            {
                if (item.Key.ToString() == key)
                    target = item;
            }
            if (target != null)
                this.keyvalList.Remove(target);
        }

        public void RemoveAt(Int32 index)
        {
            this.keyvalList.RemoveAt(index);
        }

        public Boolean ContainsKey(TKey key)
        {
            foreach (Keyval<TKey, TValue> item in keyvalList)
            {
                if (item.Key.Equals(key))
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            this.keyvalList.Clear();
        }

        public String ToString(Char innerConnector, Char outerConnector)
        {
            String result = String.Empty;
            Int32 count = keyvalList.Count;
            for (int index = 0; index < count - 1; index++)
            {
                result += (keyvalList[index].Key + innerConnector.ToString() + keyvalList[index].Value + outerConnector.ToString());
            }
            if (keyvalList.Count > 0)
                result += (keyvalList[count - 1].Key + innerConnector.ToString() + keyvalList[count - 1].Value);
            return result;
        }

        public override string ToString()
        {
            return ToString(',', ';');
        }

        public TKey[] KeyClone()
        {
            var list = new TKey[keyvalList.Count];
            for (int i = 0; i < keyvalList.Count; i++)
            {
                list[i] = keyvalList[i].Key;
            }
            return list;
        }

        public TValue[] ValueClone()
        {
            var list = new TValue[keyvalList.Count];
            for (int i = 0; i < keyvalList.Count; i++)
            {
                list[i] = keyvalList[i].Value;
            }
            return list;
        }

        #region IEnumerable 成员

        public IEnumerator GetEnumerator()
        {
            return keyvalList.GetEnumerator();
        }

        #endregion
    }

    public class Keyval<TKey, TValue>
    {
        public TKey Key { get; set; }

        public TValue Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is TKey)
                return (Object)this.Key == obj;
            else
                return false;
        }
    }
}
