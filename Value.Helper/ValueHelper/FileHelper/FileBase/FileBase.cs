/*
  >>>------ Copyright (c) 2012 zformular ----> 
 |                                            |
 |            Author: zformular               |
 |        E-mail: zformular@163.com           |
 |             Date: 10.4.2012                |
 |                                            |
 ╰==========================================╯
 
*/

using System;
using System.IO;
using ValueHelper.Infrastructure;
using ValueHelper.FileHelper.OfficeHelper;

namespace ValueHelper.FileHelper.FileBase
{
    public abstract class FileBase : IDisposable
    {
        public abstract Boolean CreateFile();

        protected String Name = null;
        protected String DPath = null;
        protected String FileName = null;
        protected String FileExtension = null;

        protected void SetParams(String fileName)
        {
            Name = Path.GetFileNameWithoutExtension(fileName);
            DPath = Path.GetDirectoryName(fileName);

            FileName = fileName;
            FileExtension = Path.GetExtension(fileName).ToLower();
        }

        protected Boolean CheckParams()
        {
            if (String.IsNullOrEmpty(Name))
                return false;
            if (String.IsNullOrEmpty(DPath))
                return false;
            if (String.IsNullOrEmpty(FileName))
                return false;
            if (String.IsNullOrEmpty(FileExtension))
                return false;

            return true;
        }

        protected void CreateDirectory()
        {
            if (!String.IsNullOrEmpty(DPath))
            {
                if (!Directory.Exists(DPath))
                {
                    Directory.CreateDirectory(DPath);
                }
            }
        }

        #region IDisposable 成员

        private Boolean disposed = false;
        protected void Dispose(Boolean disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Name = null;
                    DPath = null;
                    FileName = null;
                    FileExtension = null;
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region 析构函数

        ~FileBase()
        {
            Dispose(false);
        }

        #endregion
    }
}
