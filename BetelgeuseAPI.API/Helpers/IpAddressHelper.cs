using Microsoft.AspNetCore.Http;
namespace BetelgeuseAPI.API.Helpers
{
    public static class IpAddressHelper
    {
        public static string GenerateIpAddress(HttpRequest request)
        {
            if (request.Headers.ContainsKey("X-Forwarded-For"))
                return request.Headers["X-Forwarded-For"];
            else
                return request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
