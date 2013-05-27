using System;
using System.IO;
using ValueHelper.FileHelper.Windows;
using ValueHelper.FileHelper.OfficeHelper;

namespace ValueHelper.FileHelper
{
    public class FileManager
    {
        public static Boolean CreateFile(String fileName)
        {
            var extension = Path.GetExtension(fileName).ToLower();
            FileBase.FileBase fileBase;

            if (extension == ".doc")
            {
                fileBase = new WordHelper(fileName);
                var result = fileBase.CreateFile();
                fileBase.Dispose();

                return result;
            }
            else if (extension == "xls")
            {
                fileBase = new ExcelHelper(fileName);
                var result = fileBase.CreateFile();
                fileBase.Dispose();

                return result;
            }
            else if (extension == ".mdb")
            {
                fileBase = new AccessHelp(fileName);
                var result = fileBase.CreateFile();
                fileBase.Dispose();

                return result;
            }
            else
            {
                fileBase = new TextHelper(fileName);
                var result = fileBase.CreateFile();
                fileBase.Dispose();

                return result;
            }
        }

        public static TextHelper GetTextHelper()
        {
            return new TextHelper();
        }

        public static AccessHelp GetAccessHelp()
        {
            return new AccessHelp();
        }

        public static ExcelHelper GetExcelHelper()
        {
            return new ExcelHelper();
        }

        public static WordHelper GetWordHelper()
        {
            return new WordHelper();
        }
    }
}
