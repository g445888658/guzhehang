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
using ValueHelper.Infrastructure;
using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace ValueHelper.EncryptHelper
{
    public class DESHelper
    {
        private static Byte[] keys = { 0x46, 0x4F, 0x52, 0x4D, 0x55, 0x4C, 0x41, 0x52 };

        /// <summary>
        ///  生成密钥 每次的结果都不一样
        /// </summary>
        /// <returns></returns>
        public static String GenerateKey()
        {
            DES desCSP = DESCryptoServiceProvider.Create();
            String result = ASCIIEncoding.ASCII.GetString(desCSP.Key);
            return result;
        }

        /// <summary>
        ///  加密
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String Encrypt(String source, String key)
        {
            try
            {
                Byte[] desKey = Encoding.UTF8.GetBytes(key.Substring(0, 8));
                Byte[] desIV = keys;
                Byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
                DES desCSP = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, desCSP.CreateEncryptor(desKey, desIV),
                    CryptoStreamMode.Write);

                cryptoStream.Write(sourceBytes, 0, sourceBytes.Length);
                cryptoStream.FlushFinalBlock();

                String result = Convert.ToBase64String(memoryStream.ToArray());
                return result;
            }
            catch
            {
                return source;
            }
        }

        /// <summary>
        ///  解密
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String Decrypt(String source, String key)
        {
            try
            {
                Byte[] desKey = Encoding.UTF8.GetBytes(key);
                Byte[] desIV = keys;
                Byte[] sourceBytes = Convert.FromBase64String(source);
                DES desCSP = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, desCSP.CreateDecryptor(desKey, desIV),
                    CryptoStreamMode.Write);

                cryptoStream.Write(sourceBytes, 0, sourceBytes.Length);
                cryptoStream.FlushFinalBlock();

                String result = Encoding.UTF8.GetString(memoryStream.ToArray());
                return result;
            }
            catch
            {
                return source;
            }
        }

    }
}
