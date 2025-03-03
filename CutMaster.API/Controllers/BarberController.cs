using Microsoft.AspNetCore.Mvc;
using CutMaster.API.Data;
using CutMaster.API.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CutMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarberController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BarberController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/barber
        [HttpGet]
        public async Task<IActionResult> GetBarbers()
        {
            var barbers = await _context.Barbers.ToListAsync();
            return Ok(barbers);
        }

        // GET: api/barber/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBarber(int id)
        {
            var barber = await _context.Barbers.FindAsync(id);
            if (barber == null)
                return NotFound();

            return Ok(barber);
        }

        // POST: api/barber
        [HttpPost]
        public async Task<IActionResult> CreateBarber([FromBody] Barber barber)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Barbers.Add(barber);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBarber), new { id = barber.Id }, barber);
        }

        // PUT: api/barber/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBarber(int id, [FromBody] Barber barber)
        {
            if (id != barber.Id)
                return BadRequest();

            _context.Entry(barber).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/barber/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBarber(int id)
        {
            var barber = await _context.Barbers.FindAsync(id);
            if (barber == null)
                return NotFound();

            _context.Barbers.Remove(barber);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
