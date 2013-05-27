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
using System.Linq;
using ValueHelper.Infrastructure;
using ValueHelper.Extension;

namespace ValueHelper
{
    public class RandomHelper
    {
        private static Char[] numberKey = new Char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        private static Char[] stringKey = new Char[]{'a','b','c','d','e','f','g','h','i','j','k','l','m','n'
            ,'o','p','q','r','s','t','u','v','w','x','y','z','A','B','C','D','E','F','G','H','I','J','K','L'
            ,'M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};

        private static Char[] randomKeys = new Char[]{'0','1','2','3','4','5','6','7','8','9','a','b','c','d'
            ,'e' ,'f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z','A','B'
            ,'C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};



        public static String NewRandom()
        {
            return NewRandom(1);
        }

        public static String NewRandom(Int32 length)
        {
            return NewRandom(default(RandomType), length);
        }

        public static String NewRandom(RandomType randomType)
        {
            return NewRandom(randomType, 1);
        }

        public static String NewRandom(RandomType randomType, int length)
        {
            Random random = new Random((Int32)DateTime.Now.Ticks);
            String result = "";
            var keyLength = 0;
            switch (randomType)
            {
                case RandomType.Number:
                    keyLength = numberKey.Length;
                    for (int index = 0; index < length; index++)
                        result += numberKey[random.Next(0, keyLength)];
                    return result;

                case RandomType.String:
                    keyLength = stringKey.Length;
                    for (int index = 0; index < length; index++)
                        result += stringKey[random.Next(0, keyLength)];
                    return result;

                case RandomType.Default:
                default:
                    keyLength = randomKeys.Length;
                    for (int index = 0; index < length; index++)
                        result += randomKeys[random.Next(0, keyLength)];
                    return result;
            }
        }

        public static String NewRandom(char toplimit, char lowerlimit)
        {
            return NewRandom(default(RandomType), toplimit, lowerlimit);
        }

        public static String NewRandom(RandomType randomType, char toplimit, char lowerlimit)
        {
            return NewRandom(default(RandomType), toplimit, lowerlimit, 1);
        }

        public static String NewRandom(RandomType randomType, char toplimit, char lowerlimit, int length)
        {
            Random random = new Random((Int32)DateTime.Now.Ticks);
            String result = "";
            switch (randomType)
            {
                case RandomType.Number:
                    if (numberKey.Contains(toplimit) && numberKey.Contains(lowerlimit))
                    {
                        var startIndex = numberKey.IndexOf(toplimit);
                        var endIndex = numberKey.IndexOf(lowerlimit);
                        if (startIndex > endIndex || endIndex > numberKey.Length)
                            throw new IndexOutOfRangeException("传入字符不在要求范围内");

                        for (int index = 0; index < length; index++)
                            result += numberKey[random.Next(startIndex, endIndex)];
                        return result;
                    }
                    else
                        throw new IndexOutOfRangeException("传入字符不在要求范围内");

                case RandomType.String:
                    if (stringKey.Contains(toplimit) && stringKey.Contains(lowerlimit))
                    {
                        var startIndex = stringKey.IndexOf(toplimit);
                        var endIndex = stringKey.IndexOf(lowerlimit);
                        if (startIndex > endIndex || endIndex > stringKey.Length)
                            throw new IndexOutOfRangeException("传入字符不在要求范围内");

                        for (int index = 0; index < length; index++)
                            result += stringKey[random.Next(startIndex, endIndex)];
                        return result;
                    }
                    else
                        throw new IndexOutOfRangeException("传入字符不在要求范围内");

                case RandomType.Default:
                default:
                    if (randomKeys.Contains(toplimit) && randomKeys.Contains(lowerlimit))
                    {
                        var startIndex = randomKeys.IndexOf(toplimit);
                        var endIndex = randomKeys.IndexOf(lowerlimit);
                        if (startIndex > endIndex || endIndex > randomKeys.Length)
                            throw new IndexOutOfRangeException("传入字符不在要求范围内");

                        for (int index = 0; index < length; index++)
                            result += randomKeys[random.Next(startIndex, endIndex)];
                        return result;
                    }
                    else
                        throw new IndexOutOfRangeException("传入字符不在要求范围内");
            }
        }
    }
}
