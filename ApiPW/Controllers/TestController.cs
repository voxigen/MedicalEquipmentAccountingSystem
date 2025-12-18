using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiPW.Data;

namespace ApiPW.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("equipment")]
        public async Task<IActionResult> GetEquipment()
        {
            var equipment = await _context.Equipment
                .Include(e => e.Department)
                .Include(e => e.EquipmentType)
                .ToListAsync();

            return Ok(equipment);
        }
    }
}