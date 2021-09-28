using System.Collections.Generic;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientIpViewerController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetIP()
        {
            var ipAddress = Request.Headers["sec-fetch-user"].ToString();
            return Ok(new AppIpModel(ipAddress, GetUserIP(), GetHeaders()));
        }
        public IEnumerable<string> GetHeaders()
        {
            var realIP = Request.Headers["X-Real-IP"].ToString();
            var realForwardFor = Request.Headers["X-Forwarded-For"].ToString();
            var forwardedProto = Request.Headers["X-Forwarded-Proto"].ToString();
            return new List<string> { realIP, realForwardFor, forwardedProto };
        }

        private string GetUserIP()
        {
            GetHeaders();
            var feature = HttpContext.Features.Get<IHttpConnectionFeature>();
            return feature?.RemoteIpAddress?.ToString();
        }
    }
    public class AppIpModel
    {
        public AppIpModel(string clientIp, string remoteIp, IEnumerable<string> headers)
        {
            RemoteIp = remoteIp;
            ClientIp = clientIp;
            Headers = headers;
        }
        public string RemoteIp { get; }
        public string ClientIp { get; }
        public IEnumerable<string> Headers { get; set; }
    }
}