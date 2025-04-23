namespace HotelaATR4.RealtyPortal.AppMiddleware
{
    //app.UseMiddleware<UseWorkTime>();
    public class UseWorkTime
    {
        private readonly RequestDelegate _next;

        public UseWorkTime(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var currentHour = DateTime.Now.Hour;
            if(currentHour >= 10 && currentHour< 11)
            {
                await context.Response.WriteAsync("Не работее время");

                return;
            }

            await _next.Invoke(context);
        }
    }
}