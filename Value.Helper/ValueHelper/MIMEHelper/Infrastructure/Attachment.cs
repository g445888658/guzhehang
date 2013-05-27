using System;
using System.IO;

namespace ValueHelper.MIMEHelper.Infrastructure
{
    public class Attachment
    {
        public String Name { get; set; }

        public Byte[] Data { get; set; }

        public void Download(String path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            String fileName = Path.Combine(path, this.Name);
            FileStream fileStream = File.Create(fileName, this.Data.Length);
            fileStream.Write(this.Data, 0, this.Data.Length);
            fileStream.Close();
            fileStream.Dispose();
        }
    }
}
