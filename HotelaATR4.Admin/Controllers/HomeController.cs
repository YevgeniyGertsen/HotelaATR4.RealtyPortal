using HotelaATR4.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelaATR4.Admin.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger, AppDbContext db)
		{
			_logger = logger;
			_db = db;
        }

        public IActionResult LinkType()
        {
			var list = _db.LinkTypes.ToList();

			return View(list);
        }


        public IActionResult Position()
		{
			return View();
		}

        


        public IActionResult Index()
		{


			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
