using System;
using System.Collections;
using ValueHelper.Infrastructure;

namespace ValueHelper.MIMEHelper.Infrastructure
{
    public class MIMEHead : IKeyvalList<String, String>
    {
        private KeyvalList<String, String> keyvalList;
        public MIMEHead()
        {
            keyvalList = new KeyvalList<string, string>();
        }

        #region IKeyvalList<string,string> 成员

        public int Count
        {
            get { return keyvalList.Count; }
        }

        public string this[string key]
        {
            get
            {
                if (keyvalList.ContainsKey(key))
                    return keyvalList[key];
                return String.Empty;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Keyval<string, string> this[int index]
        {
            get
            {
                if (index < keyvalList.Count)
                    return keyvalList[index];
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Add(string key, string value)
        {
            keyvalList.Add(key, value);
        }

        public bool RemoveAt(int index)
        {
            if (keyvalList.Count > index)
            {
                keyvalList.RemoveAt(index);
                return true;
            }
            return false;
        }

        public bool Remove(string key)
        {
            if (keyvalList.ContainsKey(key))
            {
                keyvalList.Remove(key);
                return true;
            }
            return false;
        }

        #endregion
    }
}
