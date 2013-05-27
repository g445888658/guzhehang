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
using Microsoft.Office.Interop.Word;
using System.Reflection;

namespace ValueHelper.FileHelper.OfficeHelper
{
    public partial class WordHelper : FileBase.FileBase
    {
        public WordHelper() { }

        /// <summary>
        ///  设置要处理的文件
        /// </summary>
        /// <param name="fileName"></param>
        public void SetFileName(string fileName)
        {
            base.SetParams(fileName);
        }

        public WordHelper(string fileName)
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

        private Object missingValue = Missing.Value;
        private Object formate = WdSaveFormat.wdFormatDocument;
        private Boolean createFile()
        {
            try
            {
                var name = (Object)base.FileName;
                Application wordApp = new Application();
                wordApp.Visible = false;
                Document wordDoc = wordApp.Documents.Add(ref missingValue, ref missingValue, ref missingValue, ref missingValue);
                wordDoc.SaveAs(ref name, ref formate, ref missingValue, ref missingValue, ref missingValue, ref missingValue
                    , ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue
                    , ref missingValue, ref missingValue, ref missingValue, ref missingValue);
                wordDoc.Close(ref missingValue, ref missingValue, ref missingValue);
                wordApp.Quit(ref missingValue, ref missingValue, ref missingValue);
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

            var name = (Object)base.FileName;

            Application wordApp = new Application();
            wordApp.Visible = false;
            Document wordDoc = wordApp.Documents.Open(ref name, ref missingValue, ref missingValue, ref missingValue
                , ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue
                , ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue);

            String result = wordDoc.Content.Text;
            result = System.Text.RegularExpressions.Regex.Replace(result, @"\r",
                new System.Text.RegularExpressions.MatchEvaluator(delegate(System.Text.RegularExpressions.Match match)
            {
                return "\r\n";
            }), System.Text.RegularExpressions.RegexOptions.Compiled);
            wordDoc.Close(ref missingValue, ref missingValue, ref missingValue);
            wordApp.Quit(ref missingValue, ref missingValue, ref missingValue);
            return result;
        }

        #endregion

        #region Write

        public Boolean Write(String context, bool append)
        {
            if (!CheckParams())
                throw new ArgumentNullException("请先绑定文件名");

            if (!File.Exists(base.FileName))
                throw new ArgumentNullException("文件不存在");

            return write(context, append);
        }

        private Boolean write(string context, bool append)
        {
            try
            {
                Object fileName = (Object)base.FileName;
                Application wordApp = new Application();
                Document wordDoc = wordApp.Documents.Open(ref fileName, ref missingValue, ref missingValue, ref missingValue
                , ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue
                , ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue, ref missingValue);
                if (!append)
                    wordDoc.Content.Text = "";
                wordDoc.Paragraphs.Last.Range.Text += context;
                wordDoc.Save();
                wordDoc.Close(ref missingValue, ref missingValue, ref missingValue);
                wordApp.Quit(ref missingValue, ref missingValue, ref missingValue);
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion

        public new void Dispose()
        {
            missingValue = null;
            formate = null;
            base.Dispose();
        }
    }
}
