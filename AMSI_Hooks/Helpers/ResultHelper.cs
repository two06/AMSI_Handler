using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMSI_Hooks.Helpers
{
    public class ResultHelper
    {
        //https://github.com/NewOrbit/MalwareScan.AMSI/blob/master/src/MalwareScan.AMSI/MalwareScanner.cs
        public static bool ResultIsMalware(int result)
        {
            const int AMSI_RESULT_CLEAN = 0,
                      AMSI_RESULT_NOT_DETECTED = 1,
                      AMSI_RESULT_BLOCKED_BY_ADMIN_START = 16384,
                      AMSI_RESULT_BLOCKED_BY_ADMIN_END = 20479,
                      AMSI_RESULT_DETECTED = 32768;

            if (result >= AMSI_RESULT_DETECTED)
            {
                return true;
            }
            if (result >= AMSI_RESULT_BLOCKED_BY_ADMIN_START && result <= AMSI_RESULT_BLOCKED_BY_ADMIN_END)
            {
                //handle this better if needed. 
               //"The admin policy on this machine does not allow you to scan. The value returned was {scanResult}. See https://msdn.microsoft.com/en-us/library/windows/desktop/dn889584(v=vs.85).aspx"
            }
            return false;
        }
    }
}
