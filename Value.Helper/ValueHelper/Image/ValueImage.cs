using System;
using System.Drawing;
using ValueHelper.Math;
using ValueHelper.Image.Infrastructure;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ValueHelper.Image
{
    public partial class ValueImage
    {
        private ValueMath mathHelper;

        private ValueImage()
        {
            mathHelper = ValueMath.GetInstance();
        }

        private static ValueImage instance;

        public static ValueImage GetInstance()
        {
            if (instance == null)
                instance = new ValueImage();

            return instance;
        }

        #region 内存法处理图像

        private static BitmapData bmpData;
        private static Bitmap sourceImage;
        private static IntPtr ptr;
        public static Byte[] LockBits(Bitmap srcImage, ImageLockMode mode)
        {
            sourceImage = srcImage;

            var width = sourceImage.Width;
            var height = sourceImage.Height;
            var rect = new Rectangle(0, 0, width, height);
            bmpData = sourceImage.LockBits(rect, ImageLockMode.ReadOnly, sourceImage.PixelFormat);
            ptr = bmpData.Scan0;
            var byteLength = bmpData.Stride * height;
            var rgbBytes = new Byte[byteLength];
            Marshal.Copy(ptr, rgbBytes, 0, byteLength);

            return rgbBytes;
        }

        public static void UnlockBits(Byte[] rgbData)
        {
            Marshal.Copy(rgbData, 0, ptr, rgbData.Length);
            sourceImage.UnlockBits(bmpData);
        }

        public static void UnlockBits()
        {
            sourceImage.UnlockBits(bmpData);
        }

        #endregion
    }
}
