using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLogging
    {
        private readonly ILogger<RequestLogging> _logger;

        public RequestLogging(ILogger<RequestLogging> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering();

                    var buffer = new byte[context.Request.ContentLength.Value];
                    var buffer2 = context.Request.ContentLength.Value;
                    var headers = context.Request.Headers.Values;
                    var route = context.Request.RouteValues.Values;
                    await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                    var bodyAsText = Encoding.UTF8.GetString(buffer);
                    var headerAsText = Encoding.UTF8.GetString(buffer);
                    var routeAsText = Encoding.UTF8.GetString(buffer);
                    _logger.LogInformation("Request logged");
                    _logger.LogInformation(bodyAsText);

                    context.Request.Body.Position = 0;
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Could not log request body");
            }
        }
    }
}