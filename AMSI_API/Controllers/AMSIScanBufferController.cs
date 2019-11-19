using AMSI_Hooks.AntiMalwareScanInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;

namespace AMSI_API.Controllers
{
    public class AMSIScanBufferController : ApiController
    {
        public System.Web.Http.Results.JsonResult<bool> Post(HttpRequestMessage request)
        {
            var sample = request.Content.ReadAsStringAsync().Result;
            var bytes = Encoding.UTF8.GetBytes(sample);
            var scanner = new AntiMalwareScanInterface();
            var result = scanner.CallAntimalwareScanInterface(bytes);
            return Json(result);
        }
    }
}
