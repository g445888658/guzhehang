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
using System.Security.Cryptography;
using System.Text;

namespace ValueHelper.EncryptHelper
{
    public class MD5Helper
    {
        // 加密
        public static String Encrypt(String source)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            Byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            Byte[] outputBytes = md5.ComputeHash(sourceBytes);

            String result = BitConverter.ToString(outputBytes).Replace("-", "");
            return result;
        }
    }
}
