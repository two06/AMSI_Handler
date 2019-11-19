using AMSI_API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMSI_API.Helpers
{
    public class ListConverters
    {
        public static List<AMSI_RESULT> ConvertFrom(List<int> input)
        {
            var ret = new List<AMSI_RESULT>();
            foreach(var val in input)
            {
                ret.Add((AMSI_RESULT)val);
            }
            return ret;
        }
    }
}