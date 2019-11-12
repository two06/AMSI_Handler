using AMSI_Hooks.AntiMalwareScanInterface;
using AMSI_Hooks.Enums;
using Scanners.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanners
{
    public class FileScanner
    {
        public List<int> ScanFile(string fileContents)
        {
            var detections = new List<int>();
            var AMSI_Hooks = new AntiMalwareScanInterface();

            var lineNum = 1;
            foreach (string line in new LineReader(() => new StringReader(fileContents)))
            {
                var result = AMSI_Hooks.CallAntimalwareScanInterface(line);
                if (result.Equals(AMSI_RESULT.AMSI_RESULT_DETECTED))
                {
                    detections.Add(lineNum);
                }
                lineNum++;
            }

            return detections;
        }
    }
}
