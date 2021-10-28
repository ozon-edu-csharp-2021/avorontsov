using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            var serviceName = Assembly.GetExecutingAssembly().GetName().Name?.ToString() ?? "no serviceName";
            var outputStr = "{\"version\": \"" + version + "\", \"serviceName\": \"" + serviceName + "\"}";
            await context.Response.WriteAsync(outputStr);
        }
    }
}