using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace HotelaATR4.RealtyPortal.Filters
{
    public class CatchError : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            context.Result = 
                new RedirectToActionResult("Exception", "Home", new { message = context.Exception.Message });
           // context.Result = new ViewResult()
           // {
           //     ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
           //     {
           //         Model = context.Exception.Message
           //     }
           //};
        }
    }
}