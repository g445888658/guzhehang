/*
  >>>------ Copyright (c) 2012 zformular ----> 
 |                                            |
 |            Author: zformular               |
 |        E-mail: zformular@163.com           |
 |             Date: 8.29.2012                |
 |                                            |
 ╰==========================================╯
 
*/

using System;
using System.Text.RegularExpressions;
using System.Collections;

namespace ValueHelper
{
    public class StringHelper
    {
        public static String ConvertToString(String[] sources, Char separator)
        {
            var result = String.Empty;
            foreach (var item in sources)
                result += (item + separator);
            return result;
        }

        public static String[] Split(String source, Char separator)
        {
            if (String.IsNullOrEmpty(source))
                return new String[0];
            var items = source.Split(separator);
            var itemCount = 0;
            if (source.EndsWith(separator.ToString()))
                itemCount = items.Length - 1;
            else
                itemCount = items.Length;

            String[] result = new String[itemCount];
            Array.Copy(items, result, result.Length);
            return result;
        }

        /// <summary>
        ///  根据回车换行分割字符串
        ///  CRLF(carriage return/line feed)
        /// </summary>
        /// <returns></returns>
        public static String[] SplitByCRLF(String source, StringSplitOptions stringSplitOptions)
        {
            String[] result = source.Split(new String[] { "\r\n" }, stringSplitOptions);
            return result;
        }

        /// <summary>
        ///  以指定分割符合并字符串
        ///  连个元都是null则返回空字符串
        /// </summary>
        /// <param name="source"></param>
        /// <param name="adder"></param>
        /// <param name="separator"></param>
        /// <returns></returns>
        public static String Combine(String source, String adder, Char separator)
        {
            if (source == null)
            {
                if (adder == null)
                    return String.Empty;
                else
                    return adder;
            }
            else
            {
                if (adder == null)
                    return source;
                else
                {
                    return String.Concat(source, separator, adder);
                }
            }

        }
    }
}
