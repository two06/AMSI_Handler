using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSI_Hooks.Enums
{
    public enum AMSI_RESULT
    {
        AMSI_RESULT_CLEAN = 0,
        AMSI_RESULT_NOT_DETECTED = 1,
        AMSI_RESULT_DETECTED = 32768
    }
}
