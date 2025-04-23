using Microsoft.AspNetCore.Mvc;

namespace HotelaATR4.RealtyPortal.Controllers
{
    [Route("atr-hotel-rooms")]
    public class RoomController : Controller
    {
        [HttpGet("")] 
        [HttpGet("Index")]
        [HttpGet("all-rooms")]
        [HttpGet("our-rooms")]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// rooms/101 → Показать номер с ID 101
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpGet("room-details/{roomId:int}")]
		public IActionResult RoomDetails(int roomId)
        {
            return View();
        }

        /// <summary>
        /// rooms?category=luxury → Показать номера категории "люкс"
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("rooms/{category=standart}")]
		public IActionResult RoomList(string category)
        {
            return View();
        }

        /// <summary>
        /// rooms?category=standard&capacity=2 → Показать стандартные номера на 2 человек
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpGet("rooms/{category=standart}/{capacity}")]
		public IActionResult RoomList(string category, int capacity)
        {
            return View();
        }


    }
}
