using HotelaATR4.RealtyPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelaATR4.RealtyPortal.Controllers
{
    public class TemController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Team> teams = new List<Team>();
            using (var client = new HttpClient())
            {
                using (var request = await client
                                  .GetAsync("http://localhost:5148/api/Team"))
                {
                    var result = await request.Content.ReadAsStringAsync();
                    teams =JsonConvert.DeserializeObject<List<Team>>(result);
                }

            }//Dispose

            return View(teams);
        }
    }
}
