using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ValueHelper.TDCodeHelper.BasicStruct
{
    public class Converter
    {
        public static String SupplyZero(Int32 totalLength, String data)
        {
            while (data.Length < totalLength)
            {
                data = String.Concat("0", data);
            }
            return data;
        }
    }
}
