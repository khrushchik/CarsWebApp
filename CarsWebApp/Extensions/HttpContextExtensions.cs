using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace CarsWebApp.Extensions
{
    public static class HttpContextExtensions
    {
        public static string GetUserId(this HttpContext context)
        {
            return context.User?.FindFirst(ClaimTypes.Sid)?.Value;
        }
    }
}
