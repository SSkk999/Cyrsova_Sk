using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cyrsach.BLL.Services
{
    public class ServiceResponse
    {
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; } = true;
        public object? Payload { get; set; } = null;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
