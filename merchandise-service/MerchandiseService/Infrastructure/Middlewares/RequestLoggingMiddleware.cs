﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering();

                    var buffer = new byte[context.Request.ContentLength.Value];
                    var headers = context.Request.Headers.Values.ToArray();
                    var route = context.Request.Path + context.Request.Method;

                    await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);

                    var bodyAsText = Encoding.UTF8.GetString(buffer);
                    var headersAsText = string.Join("; \r\n", headers.Select(h => h.ToString()));

                    _logger.LogInformation("Request logged");
                    _logger.LogInformation(bodyAsText);
                    _logger.LogInformation(headersAsText);
                    _logger.LogInformation(route);

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