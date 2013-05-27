using System;

namespace ValueHelper.TDCodeHelper.BasicStruct
{
    public enum ModeType
    {
        /// <summary>
        ///  数字模式
        /// </summary>
        Numeric,
        /// <summary>
        ///  混合字符模式
        /// </summary>
        Alphanumeric,
        /// <summary>
        ///  8bit字节模式
        /// </summary>
        EightBitsByte,
        /// <summary>
        ///  日本汉字模式
        /// </summary>
        KANJI,
        /// <summary>
        ///  中国汉字模式
        /// </summary>
        GB2312
    }
}
