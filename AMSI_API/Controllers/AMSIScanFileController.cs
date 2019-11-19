using AMSI_API.Helpers;
using AMSI_Hooks.AntiMalwareScanInterface;
using Scanners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMSI_API.Controllers
{
    public class AMSIScanFileController : ApiController
    {
        public System.Web.Http.Results.JsonResult<List<int>> Post(HttpRequestMessage request)
        {
            var sample = request.Content.ReadAsStringAsync().Result;
            var scanner = new FileScanner();
            var result = scanner.ScanFile(sample);
            return Json(result);
        }
    }
}
