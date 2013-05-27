using System;
using System.Drawing;
using ValueHelper.TDCodeHelper.BasicStruct;
using ValueHelper.TDCodeHelper.QR2DCodeHelper.Infrastructure;
using ValueHelper.TDCodeHelper.QR2DCodeHelper.Serializer;

namespace ValueHelper.TDCodeHelper.QR2DCodeHelper
{
    public class Value2DCode : I2DCode
    {
        private String[] Sequence = new String[] { "1111111", "1000001", "1011101", "1011101", "1011101", "1011101", "1000001", "1111111" };
        private Color[] Colors = new Color[] { Color.White, Color.Black };

        #region I2DCode 成员

        public Bitmap ProduceBitmap(String data)
        {
            var matrix = new CodeMatrix(21);
            var encodeData = new ValueSerializer(ModeType.Numeric).Serialize(data);

            matrix.FillData(encodeData);

            return matrix.ConvertToBitmap();
        }

        #endregion
    }
}
