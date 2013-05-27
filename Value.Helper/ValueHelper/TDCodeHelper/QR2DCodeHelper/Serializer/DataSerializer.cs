using System;
using ValueHelper.TDCodeHelper.BasicStruct;

namespace ValueHelper.TDCodeHelper.QR2DCodeHelper.Serializer
{
    public class DataSerializer : ISerializer
    {
        protected SByte[] recognizeCode;
        protected SByte[] encodeData;

        #region ISerializer 成员

        public SByte[] ModeRecognizeCode
        {
            get { return recognizeCode; }
        }

        public virtual SByte[] Serialize(string data)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
