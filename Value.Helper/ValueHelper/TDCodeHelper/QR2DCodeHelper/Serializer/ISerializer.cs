using System;

namespace ValueHelper.TDCodeHelper.QR2DCodeHelper.Serializer
{
    public interface ISerializer
    {
        SByte[] ModeRecognizeCode { get; }
        SByte[] Serialize(String data);
    }
}
