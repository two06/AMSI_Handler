using AMSI_API.Models;
using AMSI_Hooks.AntiMalwareScanInterface;
using Scanners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AMSI_API.Controllers
{
    public class AMSIScanLineBlocksController : ApiController
    {
        public System.Web.Http.Results.JsonResult<List<BlockScanResult>> Post(int blockSize, HttpRequestMessage request)
        {
            var sample = request.Content.ReadAsStringAsync().Result;
            var lines = sample.Split(new [] { Environment.NewLine}, StringSplitOptions.None);
            var sub_sample = lines.Skip(0).Take(blockSize);
            var result = new List<BlockScanResult>();
            var scanner = new AntiMalwareScanInterface();
            var block = 1;
            while (sub_sample.Count() != 0)
            {
                var tempSample = string.Join("\r\n", sub_sample);
                var tempSampleBytes = Encoding.UTF8.GetBytes(tempSample);
                var scanResult = scanner.CallAntimalwareScanInterface(tempSampleBytes);
                if (scanResult)
                {
                    result.Add(new BlockScanResult() {BlockNumber = block, BlockText = tempSample });
                }
                
                sub_sample = lines.Skip(blockSize*block).Take(blockSize);
                block++;
            }
           
            return Json(result);
        }
    }
}
