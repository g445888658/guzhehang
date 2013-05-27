using System;
using ValueHelper.Infrastructure;
using System.Collections.Generic;

namespace ValueHelper.MIMEHelper.Infrastructure
{
    public class MIMEModel : IKeyvalList<String, String>
    {
        private KeyvalList<String, String> keyvalList;

        private IList<Attachment> attachments;
        public IList<Attachment> Attachments { get { return attachments; } }

        public MIMEModel()
        {
            keyvalList = new KeyvalList<string, string>();
            attachments = new List<Attachment>();
        }

        public void AddHead(MIMEHead head)
        {
            for (int i = 0; i < head.Count; i++)
            {
                this.keyvalList.Add(head[i]);
            }
        }

        public void AddAttachment(Attachment attachment)
        {
            this.attachments.Add(attachment);
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

        #endregion
    }
}
