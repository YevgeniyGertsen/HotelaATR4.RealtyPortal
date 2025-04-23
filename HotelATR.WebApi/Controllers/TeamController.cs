using HotelATR.WebApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelATR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TeamController : ControllerBase
    {
        private readonly AppDbContext _db;
        public TeamController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public List<Team> Get()
        {
            return _db.Teams.Include(p=>p.Position)
                            .ToList();
        }

        [HttpPost]
        public IActionResult Post([FromForm] Team team, IFormFile file)
        {
            try
            {
                if(file!=null)
                {
                    var memory = new MemoryStream();
                    file.CopyTo(memory);
                    team.ImagePath = memory.ToArray();
                }

                team.CreateAt = DateTime.Now;
                team.CreatedBy = "admin";
                _db.Teams.Add(team);
                _db.SaveChanges();

                return Ok(new { message = "Сотрудник добавлен" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}