/*
  >>>------ Copyright (c) 2012 zformular ----> 
 |                                            |
 |            Author: zformular               |
 |        E-mail: zformular@163.com           |
 |             Date: 10.3.2012                |
 |                                            |
 ╰==========================================╯
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Globalization;

namespace ValueHelper.EncryptHelper
{
    /// <summary>
    ///  Quoted-Printable 编码
    /// </summary>
    public class QPHelper
    {
        private const String QpSinglePattern = "(\\=([0-9A-F][0-9A-F]))";
        private const String QpMultiplePattern = @"((\=[0-9A-F][0-9A-F])+=?\s*)+";

        private static Char[] QpsingleElement ={'0','1','2','3','4','5','6','7','8','9',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','E','U','V','W','X','Y','Z'};
        /// <summary>
        ///  编码
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static String Encrypt(String context, Encoding encoding)
        {
            String result = String.Empty;
            Byte[] buffer = encoding.GetBytes(context);
            foreach (Byte byt in buffer)
            {
                if ((byt >= 33 && byt <= 60) || (byt >= 62 && byt <= 126))
                    result += (Char)byt;
                else
                    result += "=" + byt.ToString("X2");
            }
            return result;
        }

        public static Byte[] Decrypt(String context)
        {
            ArrayList buffer = new ArrayList();

            for (int index = 0; index < context.Length; index++)
            {
                if (context[index] == '=')
                {
                    index++;
                    if (QpsingleElement.Contains(context[index]))
                    {
                        Byte byt;
                        if (Byte.TryParse(context.Substring(index, 2),
                            NumberStyles.HexNumber, null, out byt))
                        {
                            buffer.Add(byt);
                        }
                    }
                    index++;
                }
                else if (context[index] != '\n')
                {
                    buffer.Add((Byte)context[index]);
                }
            }
            return (Byte[])buffer.ToArray(typeof(Byte));

        }

        /// <summary>
        ///  解码
        /// </summary>
        /// <param name="context"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static String Decrypt(String context, Encoding encoding)
        {
            Byte[] buffer = Decrypt(context);
            return encoding.GetString(buffer);
        }

        /// <summary>
        ///  解码2
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static String Decrypt2(String context, Encoding encoding)
        {
            String result = Regex.Replace(context, QpMultiplePattern, new MatchEvaluator(delegate(Match m)
            {
                List<Byte> buffer = new List<Byte>();
                MatchCollection matches = Regex.Matches(
                    m.Value, QpSinglePattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

                foreach (Match match in matches)
                {
                    buffer.Add((Byte)HexToByte(match.Groups[2].Value.Trim()));
                }
                return encoding.GetString(buffer.ToArray());
            }), RegexOptions.IgnoreCase | RegexOptions.Compiled);

            result = Regex.Replace(result, @"=\s+", "");
            return result;
        }

        private static Int32 HexToByte(String hex)
        {
            Int32 num = 0;
            String text = "0123456789ABCDEF";
            for (int index = 0; index < hex.Length; index++)
            {
                if (text.IndexOf(hex[index]) == -1)
                    return -1;

                num = (num * 0x10) + text.IndexOf(hex[index]);
            }

            return num;
        }
    }
}
