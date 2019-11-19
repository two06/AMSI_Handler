using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AMSI_API.Helpers
{
    public class EnumConverters
    {
        public static AMSI_API.Enums.AMSI_RESULT ConvertFrom(AMSI_Hooks.Enums.AMSI_RESULT input)
        {
            return (AMSI_API.Enums.AMSI_RESULT)input;
        }
    }
}