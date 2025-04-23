using System.Diagnostics;

namespace HotelaATR4.RealtyPortal.AppMiddleware
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<LogRequestMiddleware> _logger;
        private Stopwatch timer;

        public LogRequestMiddleware(RequestDelegate next,
            ILogger<LogRequestMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }


        public async Task Invoke(HttpContext context)
        {
            timer = Stopwatch.StartNew();
            _logger.LogInformation("Request выполнение middleware ДО");


            await _next.Invoke(context);


            timer.Stop();
            var ms = timer.Elapsed.TotalMilliseconds;
            _logger.LogInformation("Responce выполнение middleware ПОСЛЕ {ms}", ms);
        }
    }
    
    public static class LogRequestMiddlewareExtensions
    {
        public static IApplicationBuilder LogRequest(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogRequestMiddleware>();
        }
    }
}