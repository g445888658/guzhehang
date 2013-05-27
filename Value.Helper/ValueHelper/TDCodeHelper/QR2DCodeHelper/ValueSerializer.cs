using System;
using ValueHelper.TDCodeHelper.BasicStruct;

namespace ValueHelper.TDCodeHelper.QR2DCodeHelper.Serializer
{
    public class ValueSerializer
    {
        ISerializer serializer;

        public ValueSerializer(ModeType modeType)
        {
            switch (modeType)
            {
                case ModeType.Numeric:
                    serializer = new NumericSerializer();
                    break;
                case ModeType.Alphanumeric:
                    break;
                case ModeType.EightBitsByte:
                    break;
                case ModeType.KANJI:
                    break;
                case ModeType.GB2312:
                    break;
                default:
                    break;
            }
        }

        public SByte[] Serialize(String data)
        {
            return serializer.Serialize(data);
        }
    }
}
