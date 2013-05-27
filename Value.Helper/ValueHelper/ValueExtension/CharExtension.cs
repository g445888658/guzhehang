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

namespace ValueHelper.Extension
{
    public static class CharExtension
    {
        public static Int32 IndexOf(this Char[] charHelper, Char value)
        {
            var count = 0;
            for (int index = 0; index < charHelper.Length; index++)
            {
                if (charHelper[index] == value)
                    break;
                count++;
            }

            if (count == charHelper.Length)
                count = -1;
            return count;
        }
    }
}
