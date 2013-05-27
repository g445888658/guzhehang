using System;
using ValueHelper.TDCodeHelper.BasicStruct;

namespace ValueHelper.TDCodeHelper.QR2DCodeHelper.Serializer
{
    public class NumericSerializer : DataSerializer
    {
        private Int32 headLength;

        public NumericSerializer()
        {
            recognizeCode = new SByte[] { 0, 0, 0, 1 };
        }

        public override SByte[] Serialize(String data)
        {
            if (String.IsNullOrEmpty(data))
                return null;
            var totalLength = buildHead(data.Length, data);
            encodeData = new SByte[totalLength];
            var startX = 0;
            for (int i = 0; i < data.Length / 3; i++)
            {
                var value = Convert.ToString(Int32.Parse(data.Substring(startX, 3)), 2);
                value = Converter.SupplyZero(10, value);
                fillData(startX + headLength, value);
                startX += 3;
            }
            startX /= 3;
            var remainer = totalLength - startX * 10;
            if (remainer > 0)
            {
                var value = Convert.ToString(Int32.Parse(data.Substring(startX)), 2);
                value = Converter.SupplyZero(remainer, value);
                fillData(startX + headLength, value);
            }

            return encodeData;
        }

        private Int32 buildHead(Int32 dataleng, String data)
        {
            if (data == String.Empty)
                return 0;
            var remainder = data.Length % 3;
            var tailLength = 0;
            if (remainder == 1)
                tailLength = 4;
            else if (remainder == 2)
                tailLength = 7;

            var value = Convert.ToString(dataleng, 2);
            value = Converter.SupplyZero(10, value);
            for (int i = 0; i < recognizeCode.Length; i++)
                encodeData[i] = recognizeCode[i];

            headLength = recognizeCode.Length + value.Length;
            fillData(recognizeCode.Length, value);
            return recognizeCode.Length + 10 + data.Length / 3 * 10 + tailLength;
        }

        private void fillData(Int32 startIndex, String data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                encodeData[i + startIndex] = Convert.ToSByte(data[i].ToString());
            }
        }
    }
}
