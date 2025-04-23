using HotelaATR4.RealtyPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static HotelaATR4.RealtyPortal.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Serilog.Context;
using HotelaATR4.RealtyPortal.Filters;

namespace HotelaATR4.RealtyPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repository;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        //[Authorize]

        //-->[ResourceFilter]: START - OnResourceExecuting()
       //[CatchError]
        public IActionResult Index()
        {
            //-->[ActionFilter] START OnActionExecuting

            _logger.LogCritical("HomeController > Index > LogCritical");
            _logger.LogWarning("HomeController > Index > LogWarning");
            _logger.LogInformation("HomeController > Index > LogInformation");
            _logger.LogDebug("HomeController > Index > LogDebug");

            using(LogContext.PushProperty("ActionName", "Home/Index"))
            {
                _logger.LogInformation("пользователь {user} вызвал {actionName}",
                    "Guest", "Home/Index");
            }
            //-->[ResourceFilter]:EDN - OnResourceExecuted()

           
            return View();
            //--> [IResultFilter]START / END

            //-->[ActionFilter] END OnActionExecuted
        }

        //[HttpGet]
        public IActionResult Contact()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Contact(Message message)
        {
            _logger.LogInformation("шаг 1. ({date}) Пользователь {name} пытается отправить" +
                " форму на элекронный адрес {email}",
                DateTime.Now, message.Name, message.Email);

            _logger.LogInformation("шаг 2. ({name}) Начали валидацию данных", message.Name);
            MessageValidate validations = new MessageValidate();

            var result = validations.Validate(message);

            if (result.IsValid)
            {
                _logger.LogInformation("шаг 3. ({name}) Результаты валидации - {resultValid}",
                  message.Name,
                  result.IsValid);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    _logger.LogError("({name})  при отправки формы возникли ошибки: {errors}",
                   message.Name, item.ErrorMessage);
                }

                return View(message);
            }

            //if(string.IsNullOrWhiteSpace(message.Name))
            //{
            //    ModelState.AddModelError("Name", "Поле должно быть заполненным");
            //}

            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    return View(message);
            //}
        }

        public IActionResult Exception(string message)
        {
            return View("Exception", message);
        }

    }
}
