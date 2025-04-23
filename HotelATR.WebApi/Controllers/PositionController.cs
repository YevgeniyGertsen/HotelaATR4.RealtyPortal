using HotelATR.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelATR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PositionController : ControllerBase
    {
        private readonly AppDbContext _db;
        public PositionController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<Position> Get()
        {
            return _db.Positions.ToList();
        }

        [HttpPost]
        public IActionResult Post(Position position)
        {
            try
            {
                position.CreateAt = DateTime.Now;
                position.CreatedBy = "admin";

                _db.Positions.Add(position);
                _db.SaveChanges();
                return Ok(new { message = "Должность успешно добавлена"});
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
