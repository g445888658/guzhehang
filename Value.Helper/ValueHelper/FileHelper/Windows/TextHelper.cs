using System;
using System.IO;

namespace ValueHelper.FileHelper.Windows
{
    public class TextHelper : FileBase.FileBase
    {
        public TextHelper() { }

        /// <summary>
        ///  设置要处理的文件
        /// </summary>
        /// <param name="fileName"></param>
        public void SetFileName(string fileName)
        {
            base.SetParams(fileName);
        }

        public TextHelper(string fileName)
        {
            base.SetParams(fileName);
        }

        #region Create

        public override bool CreateFile()
        {
            if (CheckParams())
            {
                if (File.Exists(base.FileName))
                    return false;

                base.CreateDirectory();
                return createFile();
            }
            return false;
        }

        private bool createFile()
        {
            try
            {
                FileStream fileStream = new FileStream(base.FileName, FileMode.Create);
                fileStream.Close();
                fileStream.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Read

        public String ReadText()
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");

            return File.ReadAllText(base.FileName);
        }

        #endregion

        #region Write

        public Boolean Write(String context, Boolean append)
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");
            try
            {
                StreamWriter streamWriter = new StreamWriter(base.FileName, append);
                streamWriter.Write(context);
                streamWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Boolean WriteLine(String context, Boolean append)
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");

            try
            {
                StreamWriter streamWriter = new StreamWriter(base.FileName, append);
                streamWriter.WriteLine(context);
                streamWriter.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
