using System;

namespace ValueHelper.Image.Infrastructure
{
    public class OperatorSet
    {
        #region 拉普拉斯算子

        public static Int32[] laplacianOperator3 = new Int32[] { 0, -1, 0, -1, 3, -1, 0, -1, 0 };
        public static Int32[] laplacianOperator4 = new Int32[] { 0, -1, 0, -1, 4, -1, 0, -1, 0 };
        public static Int32[] laplacianOperator5 = new Int32[] { 0, -1, 0, -1, 5, -1, 0, -1, 0 };
        public static Int32[] setlaplacianOperator(Int32 number)
        {
            var list = new Int32[9];
            list[0] = 0;
            list[1] = -1;
            list[2] = 0;
            list[3] = -1;
            list[4] = number;
            list[5] = -1;
            list[6] = 0;
            list[7] = -1;
            list[8] = 0;

            return list;
        }
        /// <summary>
        ///  拉普拉斯4邻接算子
        /// </summary>
        public static Int32[] laplacianOperator4Adjoin = new Int32[] { 0, 1, 0, 1, -4, 1, 0, 1, 0 };
        /// <summary>
        ///  拉普拉斯8邻接算子
        /// </summary>
        public static Int32[] laplacianOperator8Adjoin = new Int32[] { 1, 1, 1, 1, -8, 1, 1, 1, 1 };
        /// <summary>
        ///  强调中心的拉普拉斯算子,此时,不在具有旋转不变性
        /// </summary>
        public static Int32[] laplacianOperatorCenter1 = new Int32[] { 2, -1, 2, -1, -4, -1, 2, -1, 2 };
        /// <summary>
        ///  强调中心的拉普拉斯算子,此时,不在具有旋转不变性
        /// </summary>
        public static Int32[] laplacianOperatorCenter2 = new Int32[] { -1, 2, -1, 2, -4, 2, -1, 2, -1 };

        #endregion

        #region Prewitt算子

        public static Int32[] prewittOperator1 = new Int32[] { 1, 1, 1, 0, 0, 0, -1, -1, -1 };
        public static Int32[] prewittOperator2 = new Int32[] { 0, 1, 1, -1, 0, 1, -1, -1, 0 };
        public static Int32[] prewittOperator3 = new Int32[] { -1, 0, 1, -1, 0, 1, -1, 0, 1 };

        #endregion

        #region Sobel算子

        public static Int32[] sobelOperator1 = new Int32[] { -1, -2, -1, 0, 0, 0, 1, 2, 1 };
        public static Int32[] sobelOperator2 = new Int32[] { 0, 1, 1, -1, 0, 1, -1, -1, 0 };
        public static Int32[] sobelOperator3 = new Int32[] { -1, 0, 1, -2, 0, 2, -1, 0, 1 };

        #endregion

        #region Robinson算子

        public static Int32[] robinsonOperator1 = new Int32[] { 1, 1, 1, 1, -2, 1, -1, -1, -1 };
        public static Int32[] robinsonOperator2 = new Int32[] { 1, 1, 1, -1, -2, 1, -1, -1, 1 };
        public static Int32[] robinsonOperator3 = new Int32[] { -1, 1, 1, -1, -2, 1, 1, 1, 1 };

        #endregion

        #region Kirsch算子

        public static Int32[] kirschOperator1 = new Int32[] { 3, 3, 3, 3, 0, 3, -5, -5, -5 };
        public static Int32[] kirschOperator2 = new Int32[] { 3, 3, 3, -5, 0, 3, -5, -5, 3 };
        public static Int32[] kirschOperator3 = new Int32[] { -5, 3, 3, -5, 0, 3, -5, 3, 3 };

        #endregion

        #region LoG算子

        public static Int32[] LoGOperator5 = new Int32[] { 
            0, 0, -1, 0, 0,
            0, -1, -2, -1, 0, 
            -1, -2, 16, -2, -1,
            0, -1, -2, -1, 0, 
            0, 0, -1, 0, 0 };

        public static Int32[] LoGOperator17 = new Int32[] { 
            0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 
            0, 0, -1, -1, -1, -2, -3, -3, -3, -3, -3, -2, -1, -1, -1, 0, 0,
            0, 0, -1, -1, -2, -3, -3, -3, -3, -3, -3, -3, -2, -1, -1, 0, 0, 
            0, -1, -1, -2, -3, -3, -3, -2, -3, -2, -3, -3, -3, -2, -1, -1, 0,
            0, -1, -2, -3, -3, -3, 0, 2, 4, 2, 0, -3, -3, -3, -2, -1, 0,
            -1, -1, -3, -3, -3, 0, 4, 10, 12, 10, 4, 0, -3, -3, -3, -1, -1,
            -1, -1, -3, -3, -2, 2, 10, 18, 21, 18, 10, 2, -2, -3, -3, -1, -1,
            -1, -1, -3, -3, -3, 4, 12, 21, 24, 21, 12, 4, -3, -3, -3, -1, -1,
            -1, -1, -3, -3, -2, 2, 10, 18, 21, 18, 10, 2, -2, -3, -3, -1, -1,
            -1, -1, -3, -3, -3, 0, 4, 10, 12, 10, 4, 0, -3, -3, -3, -1, -1,
            0, -1, -2, -3, -3, -3, 0, 2, 4, 2, 0, -3, -3, -3, -2, -1, 0,
            0, -1, -1, -2, -3, -3, -3, -2, -3, -2, -3, -3, -3, -2, -1, -1, 0, 
            0, 0, -1, -1, -2, -3, -3, -3, -3, -3, -3, -3, -2, -1, -1, 0, 0, 
            0, 0, -1, -1, -1, -2, -3, -3, -3, -3, -3, -2, -1, -1, -1, 0, 0, 
            0, 0, 0, 0, -1, -1, -1, -1, -1, -1, -1, -1, -1, 0, 0, 0, 0, 
            0, 0, 0, 0, 0, 0, -1, -1, -1, -1, -1, 0, 0, 0, 0, 0, 0 };

        #endregion
    }
}
