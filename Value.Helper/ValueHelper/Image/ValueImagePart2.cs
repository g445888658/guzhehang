using System;
using System.Drawing;
using ValueHelper.Image.Infrastructure;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ValueHelper.Image
{
    public partial class ValueImage
    {
        #region 线性点运算

        /// <summary>
        ///  对图像已指定像素按 kx+b 线性变换
        /// </summary>
        /// <param name="slope">斜率</param>
        /// <param name="displacements">平移</param>
        public void LinearChange(Bitmap srcImage, float slope, float displacements, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            var rect = new Rectangle(0, 0, width, height);
            var bmpData = srcImage.LockBits(rect, ImageLockMode.ReadWrite, srcImage.PixelFormat);
            var ptr = bmpData.Scan0;
            var byteLength = bmpData.Stride * height;
            var rgbBytes = new Byte[byteLength];
            Marshal.Copy(ptr, rgbBytes, 0, byteLength);

            float gr = 0, gg = 0, gb = 0;
            for (int i = 0; i < byteLength; i += 3)
            {
                switch (dimension)
                {
                    case FrequencyDimension.RGB:
                        gr = rgbBytes[i + 2] * slope + displacements;
                        gg = rgbBytes[i + 1] * slope + displacements;
                        gb = rgbBytes[i] * slope + displacements;
                        break;
                    case FrequencyDimension.R:
                        gr = rgbBytes[i + 2] * slope + displacements;
                        gg = gr;
                        gb = gr;
                        break;
                    case FrequencyDimension.G:
                        gg = rgbBytes[i + 1] * slope + displacements;
                        gr = gg;
                        gb = gg;
                        break;
                    case FrequencyDimension.B:
                        gb = rgbBytes[i] * slope + displacements;
                        gr = gb;
                        gg = gb;
                        break;
                }
                rgbBytes[i + 2] = (Byte)gr;
                rgbBytes[i + 1] = (Byte)gg;
                rgbBytes[i] = (Byte)gb;
            }
            Marshal.Copy(rgbBytes, 0, ptr, byteLength);
            srcImage.UnlockBits(bmpData);

        }

        #endregion

        #region 反色

        /// <summary>
        ///  反色
        /// </summary>
        public Bitmap InvertColor(Bitmap srcImage)
        {
            return this.InvertColor(srcImage, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  反色
        /// </summary>
        public Bitmap InvertColor(Bitmap srcImage, FrequencyDimension diemnsion)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var dstImage = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var pixel = srcImage.GetPixel(i, j);
                    Int32 gr = 0, gg = 0, gb = 0;
                    switch (diemnsion)
                    {
                        case FrequencyDimension.RGB:
                            gr = 255 - pixel.R;
                            gg = 255 - pixel.G;
                            gb = 255 - pixel.B;
                            break;
                        case FrequencyDimension.R:
                            gr = gg = gb = 255 - pixel.R;
                            break;
                        case FrequencyDimension.G:
                            gr = gg = gb = 255 - pixel.G;
                            break;
                        case FrequencyDimension.B:
                            gr = gg = gb = 255 - pixel.B;
                            break;
                    }
                    dstImage.SetPixel(i, j, Color.FromArgb(gr, gg, gb));
                }
            }
            return dstImage;
        }

        #endregion

        #region 平移

        /// <summary>
        ///  将图像移动x,y个单位
        /// </summary>
        /// <param name="x">水平位移</param>
        /// <param name="y">垂直位移</param>
        public void Move(Bitmap srcImage, Int32 x, Int32 y)
        {
            var rgbBytes = ValueImage.LockBits(srcImage, ImageLockMode.ReadWrite);

            var tempArray = new Byte[rgbBytes.Length];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = 255;
            }

            var length = rgbBytes.Length;
            var height = srcImage.Height;
            var width = length / height;

            for (int i = 0; i < length; i++)
            {
                // 行
                var row = i / width;
                // 列
                var col = i % width;

                var nx = (col + 3 * x);
                var ny = (row + y) * width;
                // 如果超出一行则抛弃或者小于0
                if (nx < 0) continue;
                if (nx + 2 > width) continue;

                var newPos = ny + nx;
                if (newPos < 0) continue;
                // 如果超出数组的退出循环
                if (newPos >= length) break;
                var pos = row * width + col;
                tempArray[newPos] = rgbBytes[pos];
            }

            rgbBytes = (Byte[])tempArray.Clone();

            ValueImage.UnlockBits(rgbBytes);
        }

        #endregion

        #region 镜像

        public void HoriMirror(Bitmap srcImage)
        {
            var rgbBytes = ValueImage.LockBits(srcImage, ImageLockMode.ReadWrite);
            var length = rgbBytes.Length;
            var height = srcImage.Height;
            var width = length / height;

            var splitPoint = width * 0.5F;

            var tempArray = new Byte[length];
            for (int i = 0; i < length; i++)
            {
                tempArray[i] = 255;
            }

            for (int i = 0; i < length; i += 3)
            {
                var row = i / width;
                var col = i % width;

                if (col == splitPoint)
                {
                    var xx = row * width + col;
                    tempArray[xx] = rgbBytes[xx];
                    tempArray[xx + 1] = rgbBytes[xx + 1];
                    tempArray[xx + 2] = rgbBytes[xx + 2];

                    i = (row + 1) * width;
                    continue;
                }

                var ny = 2 * splitPoint - col;

                var nx = row * width;
                var newPos = (Int32)(nx + ny);
                var pos = (Int32)(row * width + col);
                if (newPos < 0) continue;
                if (newPos + 2 > length) break;

                tempArray[newPos] = rgbBytes[pos];
                tempArray[pos] = rgbBytes[newPos];
                tempArray[newPos + 1] = rgbBytes[pos + 1];
                tempArray[pos + 1] = rgbBytes[newPos + 1];
                tempArray[newPos + 2] = rgbBytes[pos + 2];
                tempArray[pos + 2] = rgbBytes[newPos + 2];
            }
            rgbBytes = (Byte[])tempArray.Clone();

            ValueImage.UnlockBits(rgbBytes);
        }

        #endregion

        #region 切割图片

        /// <summary>
        ///  切割图片
        /// </summary>
        public Bitmap CutImage(Bitmap srcImage, Int32 locatX, Int32 locatY, Int32 width, Int32 height)
        {
            return this.CutImage(srcImage, locatX, locatY, width, height, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
        }

        /// <summary>
        ///  切割图片
        /// </summary>
        public Bitmap CutImage(Bitmap srcImage, Int32 locatX, Int32 locatY, Int32 width, Int32 height, System.Drawing.Imaging.PixelFormat format)
        {
            if (width == 0)
                width = srcImage.Width - locatX;
            if (height == 0)
                height = srcImage.Height - locatY;

            var dstWidth = srcImage.Width >= (locatX + width) ? width : srcImage.Width - locatX;
            var dstHeight = srcImage.Height >= (locatY + height) ? height : srcImage.Height - locatY;

            var dstRectagle = new Rectangle
            {
                Location = new Point(locatX, locatY),
                Size = new Size(dstWidth, dstHeight)
            };

            return srcImage.Clone(dstRectagle, format);
        }

        #endregion

        #region 灰度插值法

        /// <summary>
        ///  最近邻插值法
        /// </summary>
        public void NearestInterpolation(Bitmap srcImage, float timesX, float timesY)
        {
            Int32 height = srcImage.Height;
            byte[] rgbBytes = ValueImage.LockBits(srcImage, ImageLockMode.ReadWrite);
            Int32 length = rgbBytes.Length;
            Int32 width = length / height;

            Int32 halfWidth = width / 2;
            Int32 halfHeight = height / 2;

            Int32 tempWidth = 0, tempHeight = 0;
            Int32 xz = 0, yz = 0;
            Byte[] tempArray = new Byte[length];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    tempHeight = i - halfHeight;
                    tempWidth = j - tempWidth;

                    if (tempWidth > 0)
                        xz = (Int32)(tempWidth / timesX + 0.5);
                    else
                        xz = (Int32)(tempWidth / timesX - 0.5);

                    if (tempHeight > 0)
                        yz = (Int32)(tempHeight / timesY + 0.5);
                    else
                        yz = (Int32)(tempHeight / timesY - 0.5);

                    tempWidth = xz + halfWidth;
                    tempHeight = yz + halfHeight;
                    if (tempWidth < 0 || tempWidth >= width ||
                        tempHeight < 0 || tempHeight >= height)
                    {
                        tempArray[i * width + j] = 255;
                    }
                    else
                    {
                        tempArray[i * width + j] = rgbBytes[tempHeight * width + tempWidth];
                    }

                }
            }
            rgbBytes = (Byte[])tempArray.Clone();

            ValueImage.UnlockBits(rgbBytes);
        }

        #endregion

        #region 放大图片

        /// <summary>
        ///  放大缩小
        /// </summary>
        public Bitmap ZoomImage(Bitmap srcImage, float times)
        {
            return ZoomImage(srcImage, times, 0, 0, 0, 0);
        }

        /// <summary>
        ///  放大缩小
        /// </summary>
        public Bitmap ZoomImage(Bitmap srcImage, float times, Int32 locatX, Int32 locatY, Int32 width, Int32 height)
        {
            Bitmap cleBitmap = null;

            if (locatX == 0 && locatY == 0 && width == 0 && height == 0)
                cleBitmap = srcImage.Clone() as Bitmap;
            else
            {
                if (width == 0)
                    width = srcImage.Width - locatX;
                if (height == 0)
                    height = srcImage.Height - locatY;

                var cleRectangle = new Rectangle
                {
                    X = locatX,
                    Y = locatY,
                    Width = width,
                    Height = height
                };
                cleBitmap = srcImage.Clone(cleRectangle, System.Drawing.Imaging.PixelFormat.Format32bppRgb);
            }

            var dstWidht = Convert.ToInt32(cleBitmap.Width * times);
            var dstHeight = Convert.ToInt32(cleBitmap.Height * times);
            var dstBitmap = new Bitmap(dstWidht, dstHeight);
            var graphics = Graphics.FromImage(dstBitmap);
            // 关联补差模式
            graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawImage(srcImage, 0, 0, dstWidht, dstHeight);
            return dstBitmap;
        }

        #endregion

        #region 灰度图

        /// <summary>
        ///  转化为灰度图
        /// </summary>
        public void ConvertToGrayscale(Bitmap srcImage, GrayscaleType type)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            // 图形矩阵大小
            var rect = new Rectangle(0, 0, width, height);
            // 以可读写方式锁定全部位图像素
            var bmpData = srcImage.LockBits(rect, ImageLockMode.ReadWrite, srcImage.PixelFormat);
            // 得到图像首地址
            var ptr = bmpData.Scan0;
            // 确定字节长度
            var byteLength = bmpData.Stride * height;
            var rgbBytes = new Byte[byteLength];
            // 复制被锁定的位图像素值到该数组内
            Marshal.Copy(ptr, rgbBytes, 0, byteLength);

            var g = 0;
            // 灰度化
            for (int i = 0; i < rgbBytes.Length; i += 3)
            {
                switch (type)
                {
                    case GrayscaleType.Maximum:
                        g = mathHelper.Max(rgbBytes[i + 2], rgbBytes[i + 1], rgbBytes[i]);
                        break;
                    case GrayscaleType.Minimal:
                        g = mathHelper.Min(rgbBytes[i + 2], rgbBytes[i + 1], rgbBytes[i]);
                        break;
                    case GrayscaleType.Average:
                        g = mathHelper.Average(rgbBytes[i + 2], rgbBytes[i + 1], rgbBytes[i]);
                        break;
                }

                rgbBytes[i + 2] = rgbBytes[i + 1] = rgbBytes[i] = (Byte)g;
            }
            // 把数组赋值回位图
            Marshal.Copy(rgbBytes, 0, ptr, byteLength);
            // 解锁
            srcImage.UnlockBits(bmpData);
        }

        /// <summary>
        ///  转化为灰度图(加权灰度图)
        /// </summary>
        public void ConvertToGrayscale(Bitmap srcImage, float weightR, float weightG, float weightB)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            var rect = new Rectangle(0, 0, width, height);
            var bmpData = srcImage.LockBits(rect, ImageLockMode.ReadWrite, srcImage.PixelFormat);
            var ptr = bmpData.Scan0;
            var byteLength = bmpData.Stride * height;
            var rgbBytes = new Byte[byteLength];
            Marshal.Copy(ptr, rgbBytes, 0, byteLength);

            var g = 0F;
            for (int i = 0; i < byteLength; i += 3)
            {
                g = weightR * rgbBytes[i + 2] + weightG * rgbBytes[i + 1] + weightB * rgbBytes[i];
                rgbBytes[i + 2] = rgbBytes[i + 1] = rgbBytes[i] = (Byte)g;
            }
            Marshal.Copy(rgbBytes, 0, ptr, byteLength);
            srcImage.UnlockBits(bmpData);
        }

        #endregion

        #region 灰度拉伸

        public void GrayscaleStretch(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            //var frequency = GetFrequency(srcImage, dimension);
            //var min = mathHelper.MinIndex(frequency);
            //var max = mathHelper.MaxIndex(frequency);

            var rect = new Rectangle(0, 0, width, height);
            var bmpDate = srcImage.LockBits(rect, ImageLockMode.ReadWrite, srcImage.PixelFormat);
            var ptr = bmpDate.Scan0;
            var byteLength = bmpDate.Stride * height;
            var rgbBytes = new Byte[byteLength];
            Marshal.Copy(ptr, rgbBytes, 0, byteLength);

            Int32 min = 255, max = 0;
            for (int i = 0; i < byteLength; i += 3)
            {
                switch (dimension)
                {
                    case FrequencyDimension.RGB:
                    case FrequencyDimension.R:
                        if (rgbBytes[i + 2] < min)
                            min = rgbBytes[i + 2];

                        if (rgbBytes[i + 2] > max)
                            max = rgbBytes[i + 2];
                        break;
                    case FrequencyDimension.G:
                        if (rgbBytes[i + 1] < min)
                            min = rgbBytes[i + 1];

                        if (rgbBytes[i + 1] > max)
                            max = rgbBytes[i + 1];
                        break;
                    case FrequencyDimension.B:
                        if (rgbBytes[i] < min)
                            min = rgbBytes[i];

                        if (rgbBytes[i] > max)
                            max = rgbBytes[i];
                        break;
                }
            }


            Int32 gr = 0, gg = 0, gb = 0;
            for (int i = 0; i < byteLength; i += 3)
            {
                switch (dimension)
                {
                    case FrequencyDimension.RGB:
                        gr = (Int32)(255F / (max - min) * (rgbBytes[i + 2] - min) + 0.5);
                        gg = (Int32)(255F / (max - min) * (rgbBytes[i + 1] - min) + 0.5);
                        gb = (Int32)(255F / (max - min) * (rgbBytes[i] - min) + 0.5);
                        break;
                    case FrequencyDimension.R:
                        gr = (Int32)(255F / (max - min) * (rgbBytes[i + 2] - min) + 0.5);
                        gg = gr;
                        gb = gr;
                        break;
                    case FrequencyDimension.G:
                        gg = (Int32)(255F / (max - min) * (rgbBytes[i + 1] - min) + 0.5);
                        gr = gg;
                        gb = gg;
                        break;
                    case FrequencyDimension.B:
                        gb = (Int32)(255F / (max - min) * (rgbBytes[i] - min) + 0.5);
                        gr = gb;
                        gg = gb;
                        break;
                }
                rgbBytes[i + 2] = (Byte)gr;
                rgbBytes[i + 1] = (Byte)gg;
                rgbBytes[i] = (Byte)gb;
            }
            Marshal.Copy(rgbBytes, 0, ptr, byteLength);
            srcImage.UnlockBits(bmpDate);
        }

        /// <summary>
        ///  图像灰度拉伸
        /// </summary>
        /// <param name="x1">2拉伸点的坐标x1</param>
        /// <param name="y1">2拉伸点的坐标y1</param>
        /// <param name="x2">2拉伸点的坐标x2</param>
        /// <param name="y2">2拉伸点的坐标y2</param>
        public void GrayscaleStretch(Bitmap srcImage, Int32 x1, Int32 y1, Int32 x2, Int32 y2)
        {
            this.GrayscaleStretch(srcImage, FrequencyDimension.RGB, x1, y1, x2, y2);
        }

        /// <summary>
        ///  图像灰度拉伸
        /// </summary>
        /// <param name="x1">2拉伸点的坐标x1</param>
        /// <param name="y1">2拉伸点的坐标y1</param>
        /// <param name="x2">2拉伸点的坐标x2</param>
        /// <param name="y2">2拉伸点的坐标y2</param>
        public void GrayscaleStretch(Bitmap srcImage, FrequencyDimension dimension, Int32 x1, Int32 y1, Int32 x2, Int32 y2)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var frequence = this.GetFrequency(srcImage);

            var rect = new Rectangle(0, 0, width, height);
            var bmpData = srcImage.LockBits(rect, ImageLockMode.ReadWrite, srcImage.PixelFormat);
            var ptr = bmpData.Scan0;
            var byteLength = bmpData.Stride * height;
            var rgbBytes = new Byte[byteLength];
            Marshal.Copy(ptr, rgbBytes, 0, byteLength);

            Int32 gr = 0, gg = 0, gb = 0;
            for (int i = 0; i < byteLength; i += 3)
            {
                switch (dimension)
                {
                    case FrequencyDimension.RGB:
                        gr = grayscaleStretchAlgorithm(rgbBytes[i + 2], x1, y1, x2, y2);
                        gg = grayscaleStretchAlgorithm(rgbBytes[i + 1], x1, y1, x2, y2);
                        gb = grayscaleStretchAlgorithm(rgbBytes[i], x1, y1, x2, y2);
                        break;
                    case FrequencyDimension.R:
                        gr = grayscaleStretchAlgorithm(rgbBytes[i + 2], x1, y1, x2, y2);
                        gg = gr;
                        gb = gr;
                        break;
                    case FrequencyDimension.G:
                        gg = grayscaleStretchAlgorithm(rgbBytes[i + 1], x1, y1, x2, y2);
                        gr = gg;
                        gb = gg;
                        break;
                    case FrequencyDimension.B:
                        gr = grayscaleStretchAlgorithm(rgbBytes[i + 2], x1, y1, x2, y2);
                        gg = gr;
                        gb = gr;
                        break;
                }
                rgbBytes[i + 2] = (Byte)gr;
                rgbBytes[i + 1] = (Byte)gg;
                rgbBytes[i] = (Byte)gb;
            }
            Marshal.Copy(rgbBytes, 0, ptr, byteLength);
            srcImage.UnlockBits(bmpData);
        }

        private Int32 grayscaleStretchAlgorithm(Int32 x, Int32 x1, Int32 y1, Int32 x2, Int32 y2)
        {
            var g = 0;
            if (x < x1)
                g = (Int32)((y2 / x1) * x);
            else if (x >= x1 && x <= x2)
                g = (Int32)(((y2 - y1) / (x2 - x1)) * (x - x1) + y1);
            else if (x > x2)
                g = (Int32)(((255 - y2) / (255 - x2)) * (x - x2) + y2);
            return g;
        }

        #endregion

        #region 中值滤波

        /// <summary>
        ///  中值滤波
        /// </summary>
        public Bitmap MedianFiltering(Bitmap srcImage, MedianFilterFrame frame)
        {
            return this.MedianFiltering(srcImage, frame, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  中值滤波
        /// </summary>
        public Bitmap MedianFiltering(Bitmap srcImage, MedianFilterFrame frame, FrequencyDimension dimension)
        {
            switch (frame)
            {
                case MedianFilterFrame.F3X3:
                    return MedianFiltering3X3(srcImage, dimension);
                case MedianFilterFrame.F5X5:
                default:
                    return MedianFiltering5X5(srcImage, dimension);
            }
        }

        /// <summary>
        ///  中值滤波3x3
        /// </summary>
        public Bitmap MedianFiltering3X3(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var dstImage = new Bitmap(width, height);

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    var list = this.getFrameList(srcImage, 3, i, j, dimension);
                    mathHelper.BubbleAscending(list);

                    dstImage.SetPixel(i, j, Color.FromArgb(list[4], list[4], list[4]));
                }
            }

            for (int i = 0; i < width; i++)
            {
                dstImage.SetPixel(i, 0, srcImage.GetPixel(i, 0));
                dstImage.SetPixel(i, height - 1, srcImage.GetPixel(i, height - 1));
            }

            for (int i = 0; i < height; i++)
            {
                dstImage.SetPixel(0, i, srcImage.GetPixel(0, i));
                dstImage.SetPixel(width - 1, i, srcImage.GetPixel(width - 1, i));
            }

            return dstImage;
        }

        /// <summary>
        ///  中值滤波5x5
        /// </summary>
        public Bitmap MedianFiltering5X5(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var dstImage = new Bitmap(width, height);

            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {
                    var list = getFrameList(srcImage, 5, i, j, dimension);

                    mathHelper.BubbleAscending(list);

                    dstImage.SetPixel(i, j, Color.FromArgb(list[12], list[12], list[12]));
                }
            }

            for (int i = 0; i < width; i++)
            {
                dstImage.SetPixel(i, 0, srcImage.GetPixel(i, 0));
                dstImage.SetPixel(i, 1, srcImage.GetPixel(i, 1));
                dstImage.SetPixel(i, height - 1, srcImage.GetPixel(i, height - 1));
                dstImage.SetPixel(i, height - 2, srcImage.GetPixel(i, height - 2));
            }

            for (int i = 0; i < height; i++)
            {
                dstImage.SetPixel(0, i, srcImage.GetPixel(0, i));
                dstImage.SetPixel(1, i, srcImage.GetPixel(1, i));
                dstImage.SetPixel(width - 1, i, srcImage.GetPixel(width - 1, i));
                dstImage.SetPixel(width - 2, i, srcImage.GetPixel(width - 2, i));
            }

            return dstImage;
        }

        #endregion

        #region 二值化

        /// <summary>
        ///  二值化
        /// </summary>
        public Bitmap Binarization(Bitmap srcImage, Int32 threshold)
        {
            return this.Binarization(srcImage, FrequencyDimension.RGB, threshold);
        }

        /// <summary>
        ///  二值化
        /// </summary>
        public Bitmap Binarization(Bitmap srcImage, FrequencyDimension dimension, Int32 threshold)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            var dstImage = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var pixel = srcImage.GetPixel(i, j);
                    Int32 g = 0;
                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                            g = pixel.R < threshold ? 0 : 255;
                            break;
                        case FrequencyDimension.R:
                            g = pixel.R < threshold ? 0 : 255;
                            break;
                        case FrequencyDimension.G:
                            g = pixel.G < threshold ? 0 : 255;
                            break;
                        case FrequencyDimension.B:
                            g = pixel.B < threshold ? 0 : 255;
                            break;
                        default:
                            break;
                    }

                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }
            return dstImage;
        }

        #endregion

        #region 直方图

        /// <summary>
        ///  直方图均衡化
        /// </summary>
        /// <param name="srcImage"></param>
        /// <returns></returns>
        public void HistEqualization(Bitmap srcImage)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var number = width * height;

            var rect = new Rectangle(0, 0, width, height);
            var bmpData = srcImage.LockBits(rect, ImageLockMode.ReadWrite, srcImage.PixelFormat);
            var ptr = bmpData.Scan0;
            var byteLength = bmpData.Stride * height;
            var rgbBytes = new Byte[byteLength];
            Marshal.Copy(ptr, rgbBytes, 0, byteLength);

            Byte temp;
            var tempArray = new Int32[256];
            // 指定像素的个数
            var countPixel = new Int32[256];
            // 映射的像素集
            var pixelMap = new Byte[256];

            // 计算获得直方图
            for (int i = 0; i < byteLength; i++)
            {
                temp = rgbBytes[i];
                countPixel[temp]++;
            }

            // 生成累计归一化直方图
            // 并生成映射表
            for (int i = 0; i < 256; i++)
            {
                if (i != 0)
                {
                    tempArray[i] = tempArray[i - 1] + countPixel[i];
                }
                else
                    tempArray[0] = countPixel[0];
                pixelMap[i] = (Byte)(255.0 * tempArray[i] / byteLength + 0.5);
            }

            for (int i = 0; i < byteLength; i++)
            {
                temp = rgbBytes[i];
                rgbBytes[i] = pixelMap[temp];
            }
            Marshal.Copy(rgbBytes, 0, ptr, byteLength);
            srcImage.UnlockBits(bmpData);
        }

        /// <summary>
        ///  直方图匹配
        /// </summary>
        public void HistMatch(Bitmap srcImage, Int32[] histogram)
        {
            // 获得源图像直方图
            var frequency = this.GetFrequency(srcImage);
            var maxPixel = mathHelper.MaxIndex(frequency);

            // 内存法操作图像
            var rgbBytes = ValueImage.LockBits(srcImage, ImageLockMode.ReadWrite);

            var length = frequency.Length;
            var Hc = new Double[length];

            // 计算该直方图各灰度的累计分布函数
            Hc[0] = frequency[0];
            for (int i = 1; i < length; i++)
            {
                Hc[i] = (Hc[i - 1] + frequency[i]) / (Double)length;
            }

            Double diffA = 0D, diffB = 0D;
            var k = 0;
            var mapPixel = new Byte[length];
            for (int i = 0; i < length; i++)
            {
                diffB = 1;
                for (int j = 0; j < length; j++)
                {
                    diffA = System.Math.Abs(Hc[i] - histogram[j]);

                    //                 1.0乘以10的-8次方
                    // 找到2个累计分布函数最相似的位置
                    if (diffA - diffB < 1.0E-08)
                    {
                        // 记下差值
                        diffB = diffA;
                        k = j;
                    }
                    else
                    {
                        // 已找到为相似位置,记录并退出
                        k = j - 1;
                        break;
                    }
                }

                // 如果达到最大灰度级,标志未处理灰度数,并推出循环
                if (k == 255)
                {
                    for (int l = 0; l < length; l++)
                    {
                        mapPixel[l] = (Byte)k;
                    }
                    break;
                }
                mapPixel[i] = (Byte)k;
            }

            for (int i = 0; i < rgbBytes.Length; i++)
            {
                rgbBytes[i] = mapPixel[rgbBytes[i]];
            }

            ValueImage.UnlockBits(rgbBytes);
        }

        #endregion

        #region Ostu算法二值化

        /// <summary>
        ///  Ostu算法二值化
        /// </summary>
        public Bitmap OstuVary(Bitmap srcImage)
        {
            return this.OstuVary(srcImage, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  Ostu算法二值化
        /// </summary>
        public Bitmap OstuVary(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var frequency = this.GetFrequency(srcImage);
            var index = mathHelper.OstuThreshold(frequency, width * height);

            var dstImage = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var pixel = srcImage.GetPixel(i, j);
                    var g = 0;

                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                        case FrequencyDimension.R:
                            g = pixel.R >= index ? 255 : 0;
                            break;
                        case FrequencyDimension.G:
                            g = pixel.G >= index ? 255 : 0;
                            break;
                        case FrequencyDimension.B:
                            g = pixel.B >= index ? 255 : 0;
                            break;
                    }
                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return dstImage;
        }

        #endregion

        #region kFill种子填色算法

        /// <summary>
        ///  kFill种子填色方法
        /// </summary>
        public Bitmap KFill(Bitmap srcImage)
        {
            return this.KFill(srcImage, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  kFill种子填色方法
        /// </summary>
        public Bitmap KFill(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            for (int i = 2; i < width - 2; i++)
            {
                for (int j = 2; j < height - 2; j++)
                {
                    var pixel = srcImage.GetPixel(i, j);
                    var g = 0;
                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                        case FrequencyDimension.R:
                            g = pixel.R;
                            break;
                        case FrequencyDimension.G:
                            g = pixel.G;
                            break;
                        case FrequencyDimension.B:
                            g = pixel.B;
                            break;
                    }

                    // 处理黑色噪声
                    if (g == 0)
                    {
                        var list = getFrameList(srcImage, 5, i, j, dimension);
                        var n = 0;
                        for (int le = 0; le < list.Length; le++)
                        {
                            if (list[le] == 255)
                                n++;
                        }

                        var r = 0;
                        if (list[0] == 255)
                            r++;
                        if (list[4] == 255)
                            r++;
                        if (list[20] == 255)
                            r++;
                        if (list[24] == 255)
                            r++;

                        if (n > (3 * 5 - 5 / 3) || ((n == 3 * 5 - 5 / 3) && (r == 2)))
                        {
                            srcImage.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                        }
                    }
                    // 处理白色噪声
                    else if (g == 255)
                    {
                        var list = getFrameList(srcImage, 5, i, j, dimension);
                        var n = 0;
                        for (int le = 0; le < list.Length; le++)
                        {
                            if (list[le] == 0)
                                n++;
                        }

                        var r = 0;
                        if (list[0] == 0)
                            r++;
                        if (list[4] == 0)
                            r++;
                        if (list[20] == 0)
                            r++;
                        if (list[24] == 0)
                            r++;

                        if (n > (3 * 5 - 5 / 3) || ((n == 3 * 5 - 5 / 3) && (r == 2)))
                        {
                            srcImage.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
            }

            return srcImage;
        }

        #endregion

        #region Roberts锐化

        /// <summary>
        ///  Roberts锐化
        /// </summary>
        public Bitmap RobertsSharpen(Bitmap srcImage)
        {
            return this.RobertsSharpen(srcImage, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  Roberts锐化
        /// </summary>
        public Bitmap RobertsSharpen(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var dstImage = new Bitmap(width, height);

            Int32[] list = null;
            for (int i = 0; i < width - 1; i++)
            {
                for (int j = 0; j < height - 1; j++)
                {
                    list = new Int32[4];
                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                        case FrequencyDimension.R:
                            {
                                list[0] = srcImage.GetPixel(i, j).R;
                                list[1] = srcImage.GetPixel(i + 1, j).R;
                                list[2] = srcImage.GetPixel(i, j + 1).R;
                                list[3] = srcImage.GetPixel(i + 1, j + 1).R;
                            }
                            break;
                        case FrequencyDimension.G:
                            {
                                list[0] = srcImage.GetPixel(i, j).G;
                                list[1] = srcImage.GetPixel(i + 1, j).G;
                                list[2] = srcImage.GetPixel(i, j + 1).G;
                                list[3] = srcImage.GetPixel(i + 1, j + 1).G;
                            }
                            break;
                        case FrequencyDimension.B:
                            {
                                list[0] = srcImage.GetPixel(i, j).B;
                                list[1] = srcImage.GetPixel(i + 1, j).B;
                                list[2] = srcImage.GetPixel(i, j + 1).B;
                                list[3] = srcImage.GetPixel(i + 1, j + 1).B;
                            }
                            break;
                    }

                    var g = System.Math.Abs(list[0] - list[3]) + System.Math.Abs(list[2] - list[1]);
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;

                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }
            return dstImage;
        }

        #endregion

        #region 拉普拉斯算子锐化

        /// <summary>
        ///  拉普拉斯算子锐化
        /// </summary>
        public Bitmap LaplacianSharpen(Bitmap srcImage, float strength, Int32[] laplacianOperator)
        {
            return this.LaplacianSharpen(srcImage, strength, laplacianOperator, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  拉普拉斯算子锐化
        /// </summary>
        public Bitmap LaplacianSharpen(Bitmap srcImage, float strength, Int32[] raplacianOperator, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            var dstImage = new Bitmap(width, height);
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    var pixel = srcImage.GetPixel(i, j);
                    var list = getFrameList(srcImage, 3, i, j, dimension);
                    var rapOpera = 0;
                    for (int ri = 0; ri < 9; ri++)
                    {
                        rapOpera += list[ri] * raplacianOperator[ri];
                    }

                    var g = 0;
                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                        case FrequencyDimension.R:
                            g = (Int32)(pixel.R - strength * rapOpera);
                            break;
                        case FrequencyDimension.G:
                            g = (Int32)(pixel.G - strength * rapOpera);
                            break;
                        case FrequencyDimension.B:
                            g = (Int32)(pixel.B - strength * rapOpera);
                            break;
                    }
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;

                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return dstImage;
        }

        #endregion

        #region Prewitt锐化

        /// <summary>
        ///  Prewitt锐化
        /// </summary>
        public Bitmap PrewittSharpen(Bitmap srcImage, Int32[] prewittOperator)
        {
            return this.PrewittSharpen(srcImage, prewittOperator, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  Prewitt锐化
        /// </summary>
        public Bitmap PrewittSharpen(Bitmap srcImage, Int32[] prewittOperator, FrequencyDimension dimension)
        {
            return Marsk3Operator(srcImage, prewittOperator, dimension);
        }

        #endregion

        #region Sobel边缘检测

        public Bitmap SobelSharpen(Bitmap srcImage)
        {
            return this.SobelSharpen(srcImage, FrequencyDimension.RGB);
        }

        public Bitmap SobelSharpen(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            var dstImage = new Bitmap(width, height);
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    var list = getFrameList(srcImage, 3, i, j, dimension);
                    var operX = OperatorSet.robinsonOperator1;
                    var operY = OperatorSet.robinsonOperator3;
                    Int32 gx = 0, gy = 0, g = 0;
                    for (int ii = 0; ii < 9; ii++)
                    {
                        gx += list[ii] * operX[ii];
                        gy += list[ii] * operY[ii];
                    }

                    g = System.Math.Abs(gx) + System.Math.Abs(gy);
                    g = g > 255 ? 255 : g;
                    g = g < 0 ? 0 : g;

                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return dstImage;
        }

        #endregion

        #region Robinsion锐化

        /// <summary>
        ///  Robinson锐化
        /// </summary>
        public Bitmap RobinsonSharpen(Bitmap srcImage, Int32[] robinsonOperator)
        {
            return this.RobinsonSharpen(srcImage, robinsonOperator, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  Robinson锐化
        /// </summary>
        public Bitmap RobinsonSharpen(Bitmap srcImage, Int32[] robinsonOperator, FrequencyDimension dimension)
        {
            return Marsk3Operator(srcImage, robinsonOperator, dimension);
        }

        #endregion

        #region Kirsch锐化

        /// <summary>
        ///  Kirsch锐化
        /// </summary>
        public Bitmap KirschSharpen(Bitmap srcImage, Int32[] kirschOperator)
        {
            return this.KirschSharpen(srcImage, kirschOperator);
        }

        /// <summary>
        ///  Kirsch锐化
        /// </summary>
        public Bitmap KirschSharpen(Bitmap srcImage, Int32[] kirschOperator, FrequencyDimension dimension)
        {
            return Marsk3Operator(srcImage, kirschOperator, dimension);
        }

        #endregion

        #region LoG5x5锐化

        /// <summary>
        ///  LoG5x5锐化
        /// </summary>
        public Bitmap LoG5Sharpen(Bitmap srcImage)
        {
            return this.LoG5Sharpen(srcImage, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  LoG5x5锐化
        /// </summary>
        public Bitmap LoG5Sharpen(Bitmap srcImage, FrequencyDimension dimension)
        {
            return Marsk5Operator(srcImage, OperatorSet.LoGOperator5, dimension);
        }

        #endregion

        #region LoG17x17锐化

        /// <summary>
        ///  LoG17x17锐化
        /// </summary>
        public Bitmap LoG17Sharpen(Bitmap srcImage)
        {
            return this.LoG17Sharpen(srcImage, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  LoG17x17锐化
        /// </summary>
        public Bitmap LoG17Sharpen(Bitmap srcImage, FrequencyDimension dimension)
        {
            return Marsk17Operator(srcImage, OperatorSet.LoGOperator17, dimension);
        }

        #endregion

        #region 最优阈值化

        /// <summary>
        ///  最优阈值二值化
        /// </summary>
        public Bitmap OptimalThreshold(Bitmap srcImage)
        {
            return this.OptimalThreshold(srcImage, FrequencyDimension.RGB);
        }

        /// <summary>
        ///  最优阈值二值化
        /// </summary>
        public Bitmap OptimalThreshold(Bitmap srcImage, FrequencyDimension dimension)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;
            var frequency = this.GetFrequency(srcImage);

            #region 首次迭代

            var T = 0F;
            var T1 = 0F;
            var utb = 0F;
            var uto = 0F;
            switch (dimension)
            {
                case FrequencyDimension.RGB:
                case FrequencyDimension.R:
                    utb = (srcImage.GetPixel(0, 0).R + srcImage.GetPixel(width - 1, height - 1).R +
                        srcImage.GetPixel(0, height - 1).R + srcImage.GetPixel(width - 1, 0).R);
                    break;
                case FrequencyDimension.G:
                    utb = (srcImage.GetPixel(0, 0).G + srcImage.GetPixel(width - 1, height - 1).G +
                        srcImage.GetPixel(0, height - 1).G + srcImage.GetPixel(width - 1, 0).G);
                    break;
                case FrequencyDimension.B:
                    utb = (srcImage.GetPixel(0, 0).B + srcImage.GetPixel(width - 1, height - 1).B +
                        srcImage.GetPixel(0, height - 1).B + srcImage.GetPixel(width - 1, 0).B);
                    break;
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                        case FrequencyDimension.R:
                            uto += srcImage.GetPixel(i, j).R;
                            break;
                        case FrequencyDimension.G:
                            uto += srcImage.GetPixel(i, j).G;
                            break;
                        case FrequencyDimension.B:
                            uto += srcImage.GetPixel(i, j).B;
                            break;
                    }

                }
            }

            uto = (uto - utb) / (width * height - 4);
            utb = utb / 4;
            T = (utb + uto) / 2;

            #endregion

            #region 持续迭代直至满足条件

            var nub = 0;
            var nuo = 0;
            while (T1 != T)
            {
                utb = uto = nub = nuo = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        var g = 0;
                        switch (dimension)
                        {
                            case FrequencyDimension.RGB:
                            case FrequencyDimension.R:
                                g = srcImage.GetPixel(i, j).R;
                                break;
                            case FrequencyDimension.G:
                                g = srcImage.GetPixel(i, j).G;
                                break;
                            case FrequencyDimension.B:
                                g = srcImage.GetPixel(i, j).B;
                                break;
                        }

                        if (g < T)
                        {
                            utb += g;
                            nub++;
                        }
                        else
                        {
                            uto += g;
                            nuo++;
                        }
                    }
                }

                utb = utb / nub;
                uto = uto / nuo;
                T1 = T;
                T = (utb + uto) / 2;
            }

            #endregion

            var dstImage = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    var pixel = srcImage.GetPixel(i, j);
                    var g = 0;
                    switch (dimension)
                    {
                        case FrequencyDimension.RGB:
                        case FrequencyDimension.R:
                            g = pixel.R >= T ? 255 : 0;
                            break;
                        case FrequencyDimension.G:
                            g = pixel.G >= T ? 255 : 0;
                            break;
                        case FrequencyDimension.B:
                            g = pixel.B >= T ? 255 : 0;
                            break;
                    }

                    dstImage.SetPixel(i, j, Color.FromArgb(g, g, g));
                }
            }

            return dstImage;
        }

        #endregion

        #region 内边界提取

        public Bitmap InnerBorder(Bitmap srcImage)
        {
            return this.InnerBorder(srcImage, 0);
        }

        public Bitmap InnerBorder(Bitmap srcImage, Int32 borderPixel)
        {
            var width = srcImage.Width;
            var height = srcImage.Height;

            var chains = new List<Chain>();

            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {
                    Int32 x = i, y = j;
                    if (srcImage.GetPixel(x, y).R == borderPixel)
                    {
                        var dir = 7;
                        var chain = new Chain();

                        while (chain.AddNode(new ChainNode
                        {
                            X = x,
                            Y = y,
                            Dir = dir
                        }))
                        {
                            var list = getFrameListAnticlockwise(srcImage, 8, x, y);
                            for (int ii = 0; ii < 8; ii++)
                            {
                                if (list[dir] == borderPixel)
                                {
                                    x += antiClockwiseDirection[dir][0];
                                    y += antiClockwiseDirection[dir][1];
                                }
                                else
                                {
                                    dir++;
                                    dir = dir > 7 ? 0 : dir;
                                }
                            }

                            dir = dir % 2 == 0 ? ((dir + 7) % 8) : ((dir + 6) / 8);

                        }

                        if (chain.Length > 1)
                            chains.Add(chain);
                    }
                }
            }

            var dstImage = new Bitmap(width, height);
            for (int i = 0; i < chains.Count; i++)
            {
                var chain = chains[i];
                for (int j = 0; j < chain.Length; j++)
                {
                    dstImage.SetPixel(chain[j].X, chain[j].Y, Color.Blue);
                }
            }

            return dstImage;
        }

        private Point getNextPosition(Int32 i, Int32 j, Int32 direct)
        {
            switch (direct)
            {
                case 0:
                    return new Point(i + 1, j);
                case 1:
                    return new Point(i + 1, j - 1);
                case 2:
                    return new Point(i, j - 1);
                case 3:
                    return new Point(i - 1, j - 1);
                case 4:
                    return new Point(i - 1, j);
                case 5:
                    return new Point(i - 1, j + 1);
                case 6:
                    return new Point(i, j + 1);
                case 7:
                    return new Point(i + 1, j + 1);
                default:
                    return new Point(i, j);
            }
        }

        #endregion
    }
}
