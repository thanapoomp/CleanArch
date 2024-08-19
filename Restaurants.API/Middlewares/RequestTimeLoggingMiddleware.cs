
namespace Restaurants.API.Middlewares
{
    public class RequestTimeLoggingMiddleware(ILogger<RequestTimeLoggingMiddleware> logger) : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var startTime = DateTime.Now;
            await next.Invoke(context);
            var endTime = DateTime.Now;
            var durationSec = (endTime - startTime).TotalSeconds;
            if (durationSec > 4)
            {
                logger.LogWarning("Request slow at {path} duration : {duration}",context.Request.Path,durationSec);
            }
        }
    }
}
