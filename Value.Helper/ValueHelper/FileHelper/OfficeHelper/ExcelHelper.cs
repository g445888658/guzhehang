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
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace ValueHelper.FileHelper.OfficeHelper
{
    public partial class ExcelHelper : FileBase.FileBase
    {
        public ExcelHelper() { }

        /// <summary>
        ///  设置要处理的文件
        /// </summary>
        /// <param name="fileName"></param>
        public ExcelHelper(string fileName)
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
        private Boolean createFile()
        {
            try
            {
                Application excelApp = new Application();
                excelApp.Visible = false;
                Workbook excelBook = excelApp.Workbooks.Add(missingValue);
                excelBook.SaveAs(base.FileName, missingValue, missingValue, missingValue, missingValue, missingValue, XlSaveAsAccessMode.xlNoChange
                    , missingValue, missingValue, missingValue, missingValue, missingValue);
                excelBook.Close(missingValue, missingValue, missingValue);
                excelApp.Quit();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public new void Dispose()
        {
            missingValue = null;
            base.Dispose();
        }

        #endregion
    }
}
