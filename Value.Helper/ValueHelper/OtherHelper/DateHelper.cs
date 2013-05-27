using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueHelper.OtherHelper
{
    public static class DateHelper
    {
        /// <summary>
        ///  将英文月份转化为数字
        /// </summary>
        /// <param name="month">Otc, Jan</param>
        /// <returns></returns>
        public static String ConvertEnToNum(String month)
        {
            month = month.ToLower();
            switch (month)
            {
                case "jan": return "1";
                case "feb": return "2";
                case "mar": return "3";
                case "apr": return "4";
                case "may": return "5";
                case "jun": return "6";
                case "jul": return "7";
                case "aug": return "8";
                case "sep": return "9";
                case "oct": return "10";
                case "nov": return "11";
                case "dec": return "12";
                default: return "";
            }
        }
    }
}
