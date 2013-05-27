using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using ValueHelper.Image.Infrastructure;

namespace ValueHelper.Image
{
    public partial class ValueImage
    {
        /// <summary>
        ///  获得指定维度图像数值实现频率
        /// </summary>
        /// <param name="dimension">RGB是统计所有的像素, 其他都只统计个别的</param>
        /// <returns></returns>
        public Int32[] GetFrequency(Bitmap srcImage)
        {
            var frequnce = new Int32[256];

            var rgbBytes = ValueImage.LockBits(srcImage, ImageLockMode.ReadOnly);
            var byteLength = rgbBytes.Length;

            var f = 0;
            for (int i = 0; i < byteLength; i += 3)
            {
                f = rgbBytes[i];
                frequnce[f]++;
            }

            ValueImage.UnlockBits();

            return frequnce;
        }

        /// <summary>
        ///  3x3掩膜算法
        /// </summary>
        public Bitmap Marsk3Operator(Bitmap srcImage, Int32[] operators, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var dstImage = new Bitmap(width, height);
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    var list = getFrameList(srcImage, 3, i, j, dimension);
                    var g = 0;

                    for (int ii = 0; ii < 9; ii++)
                    {
                        g += list[ii] * operators[ii];
                    }
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;
                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return dstImage;
        }

        /// <summary>
        ///  4x4掩膜算法
        /// </summary>
        public Bitmap Marsk5Operator(Bitmap srcImage, Int32[] operators, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var dstImage = new Bitmap(width, height);
            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {
                    var list = getFrameList(srcImage, 5, i, j, dimension);
                    var g = 0;
                    for (int ii = 0; ii < 25; ii++)
                    {
                        g += list[ii] * operators[ii];
                    }
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;

                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return dstImage;
        }

        /// <summary>
        ///  17x17掩膜算法
        /// </summary>
        public Bitmap Marsk17Operator(Bitmap srcImage, Int32[] operators, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var dstImage = new Bitmap(width, height);
            for (int i = 8; i < width - 8; i++)
            {
                for (int j = 8; j < height - 8; j++)
                {
                    var list = getFrameList(srcImage, 17, i, j, dimension);
                    var g = 0;
                    for (int ii = 0; ii < 17; ii++)
                    {
                        g += list[ii] * operators[ii];
                    }
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;

                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return dstImage;
        }

        /// <summary>
        ///  获得图像的当前像素的为中心的 sizeXsize 数组
        /// </summary>
        private Int32[] getFrameList(Bitmap srcImage, Int32 size, Int32 i, Int32 j, FrequencyDimension dimension)
        {
            var list = new Int32[size * size];
            var index = 0;
            var border = (size - 1) / 2;
            for (int ii = -border; ii <= border; ii++)
            {
                for (int ij = -border; ij <= border; ij++)
                {
                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                            list[index] = srcImage.GetPixel(i - ii, j - ij).R;
                            break;
                        case FrequencyDimension.R:
                            list[index] = srcImage.GetPixel(i - ii, j - ij).R;
                            break;
                        case FrequencyDimension.G:
                            list[index] = srcImage.GetPixel(i - ii, j - ij).G;
                            break;
                        case FrequencyDimension.B:
                            list[index] = srcImage.GetPixel(i - ii, j - ij).B;
                            break;
                    }

                    index++;
                }
            }
            return list;
        }

        /// <summary>
        ///  8-邻接逆时针x,y增量
        /// </summary>
        private Int32[][] antiClockwiseDirection = new Int32[8][] { 
            new Int32[] { 1, 0 }, new Int32[] { 1, -1 }, new Int32[] { 0, -1 }, new Int32[] { -1, -1 }, 
            new Int32[] { -1, 0 }, new Int32[] { -1, 1 }, new Int32[] { 0, 1 }, new Int32[] { 1, 1 } };

        /// <summary>
        ///  4-邻接逆时针x,y增量
        /// </summary>
        private Int32[][] antiClockwiseDirection4 = new Int32[4][] { new Int32[] { 1, 0 }, new Int32[] { 0, -1 }, new Int32[] { -1, 0 }, new Int32[] { 0, 1 } };

        /// <summary>
        ///  获得图像8-邻接逆时针数组
        /// </summary>
        private Int32[] getFrameListAnticlockwise(Bitmap srcImage, Int32 adjoinType, Int32 i, Int32 j)
        {
            if (adjoinType == 8)
            {
                var list = new Int32[8];
                for (int ii = 0; ii < 8; ii++)
                {
                    list[ii] = srcImage.GetPixel(i + antiClockwiseDirection[ii][0], j + antiClockwiseDirection[ii][1]).R;
                }
                return list;
            }
            else
            {
                var list = new Int32[4];
                for (int ii = 0; ii < 4; ii++)
                {
                    list[ii] = srcImage.GetPixel(i + antiClockwiseDirection4[ii][0], j + antiClockwiseDirection4[ii][1]).R;
                }
                return list;
            }
        }

        /// <summary>
        ///  8-邻接顺时针的x,y 增量
        /// </summary>
        private Int32[][] clockwiseDirection = new Int32[8][] { 
            new Int32[] { -1, 0 }, new Int32[] { -1, -1 }, new Int32[] { 0, -1 }, new Int32[] { 1, -1 }, 
            new Int32[] { 1, 0 }, new Int32[] { 1, 1 }, new Int32[] { 0, 1 }, new Int32[] { -1, 1 } };

        /// <summary>
        ///  4-邻接顺时针的x,y 增量
        /// </summary>
        private Int32[][] clockwiseDirection4 = new Int32[4][] { new Int32[] { -1, 0 }, new Int32[] { 0, -1 }, new Int32[] { 1, 0 }, new Int32[] { 0, 1 } };

        /// <summary>
        ///  获得图像8-邻接顺时针数组
        /// </summary>
        private Int32[] getFrameListClockwise(Bitmap srcImage, Int32 adjoinType, Int32 i, Int32 j)
        {
            if (adjoinType == 8)
            {
                var list = new Int32[8];
                for (int ii = 0; ii < 8; ii++)
                {
                    list[ii] = srcImage.GetPixel(i + clockwiseDirection[ii][0], j + clockwiseDirection[ii][1]).R;
                }
                return list;
            }
            else
            {
                var list = new Int32[4];
                for (int ii = 0; ii < 4; ii++)
                {
                    list[ii] = srcImage.GetPixel(i + clockwiseDirection4[ii][0], j + clockwiseDirection4[ii][1]).R;
                }
                return list;
            }
        }
    }
}
