using System;

namespace ValueHelper.TDCodeHelper.QR2DCodeHelper.Infrastructure
{
    public class ProperStruct
    {
        /// <summary>
        ///  位置探测图形
        /// </summary>
        public static SByte[][] PDG = { 
                                          new SByte[] { 1, 1, 1, 1, 1, 1, 1 },
                                          new SByte[] { 1, 0, 0, 0, 0, 0, 1 },
                                          new SByte[] { 1, 0, 1, 1, 1, 0, 1 },
                                          new SByte[] { 1, 0, 1, 1, 1, 0, 1 },
                                          new SByte[] { 1, 0, 1, 1, 1, 0, 1 },
                                          new SByte[] { 1, 0, 0, 0, 0, 0, 1 },
                                          new SByte[] { 1, 1, 1, 1, 1, 1, 1 }
                                      };

        /// <summary>
        ///  矫正图形
        /// </summary>
        public static SByte[][] CCG = { 
                                          new SByte[] { 1, 1, 1, 1, 1 },
                                          new SByte[] { 1, 0, 0, 0, 1 },
                                          new SByte[] { 1, 0, 1, 0, 1 },
                                          new SByte[] { 1, 0, 0, 0, 1 },
                                          new SByte[] { 1, 1, 1, 1, 1 }
                                      };

        /// <summary>
        ///  定位图形
        /// </summary>
        public static SByte[] NPG = { 1, 0 };
    }
}
