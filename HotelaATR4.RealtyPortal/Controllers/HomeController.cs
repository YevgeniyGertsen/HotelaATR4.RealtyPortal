using HotelaATR4.RealtyPortal.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static HotelaATR4.RealtyPortal.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelaATR4.RealtyPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository repository;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger,
            IRepository repo,
            IWebHostEnvironment webHostEnvironment
            )
        {
            _logger = logger;
            repository = repo;
            _webHostEnvironment = webHostEnvironment;

        }

        public IActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Message message)
        {

            MessageValidate validations = new MessageValidate();
            var result = validations.Validate(message);

            var errors = result.Errors;

            if (result.IsValid)
            {
                return RedirectToAction("Index");
            }
            else
            {
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

    }
}
