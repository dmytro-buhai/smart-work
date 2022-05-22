using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace SmartWork.Utils.Middlewares
{
    public class RoutingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RoutingMiddleware> _logger;

        public RoutingMiddleware(RequestDelegate next, ILogger<RoutingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var url = context.Request.GetDisplayUrl();
            
            _logger.LogInformation(string.Concat(
                url, "\n", 
                "\tHeaders: ", string.Join("\n\t", context.Request.Headers)
             ));

            await _next.Invoke(context);
        }
    }
}
