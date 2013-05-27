/*
  >>>----- Copyright (c) 2012 zformular -----> 
 |                                            |
 |              Author: zformular             |
 |          E-mail: zformular@163.com         |
 |               Date: 9.27.2012              |
 |                                            |
 ╰==========================================╯
 
 */

using System;
using System.Text;
using ValueHelper.EncryptHelper;

namespace ValueHelper.MIMEHelper.Infrastructure
{
    public class MIMEncrypt
    {
        /// <summary>
        ///  解码
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="contentTransferEncoding"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static String ConvertEncoding(String charset, String contentTransferEncoding, String context)
        {
            try
            {
                if (charset == "utf8") charset = "UTF-8";

                Byte[] bytes = GetBytesByPattern(contentTransferEncoding, context);
                String result = Encoding.GetEncoding(charset).GetString(bytes);
                return result;
            }
            catch
            {
                throw new NotImplementedException("不支持'" + charset + "'编码格式");
            }

        }

        /// <summary>
        ///  邮件MIME常用编码格式
        ///  Base64 和 Quoted-Printable
        ///  通过次方法获得相应的字节数组
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static Byte[] GetBytesByPattern(String pattern, String context)
        {
            Byte[] bytes;
            pattern = pattern.ToLower();
            switch (pattern)
            {
                case "q":
                case "quoted-printable":
                    bytes = QPHelper.Decrypt(context);
                    break;
                case "b":
                case "base64":
                    bytes = Convert.FromBase64String(context);
                    break;
                default:
                    bytes = Encoding.ASCII.GetBytes(context);
                    break;
            }
            return bytes;
        }
    }
}
