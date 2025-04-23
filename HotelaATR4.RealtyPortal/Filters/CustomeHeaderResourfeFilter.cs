using Microsoft.AspNetCore.Mvc.Filters;

namespace HotelaATR4.RealtyPortal.Filters
{
    public class CustomeHeaderResourfeFilter :  IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {
           
        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            context.HttpContext.Response.Headers.Add("X-Customer-Header", "MyCustomValue");
        }
    }
}
