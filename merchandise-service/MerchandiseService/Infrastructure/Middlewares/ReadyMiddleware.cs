using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Middlewares
{
    public class ReadyMiddleware
    {
        public ReadyMiddleware(RequestDelegate next)
        {
        }

        [ProducesResponseType(typeof(ReadyMiddleware), StatusCodes.Status200OK)]
        public Task InvokeAsync(HttpContext context)
        {
            return Task.CompletedTask; // StatusCodes.Status200OK;
        }
    }
}