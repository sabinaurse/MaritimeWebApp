using Microsoft.AspNetCore.Mvc;
using MaritimeWebApp.Server.Data;
using MaritimeWebApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MaritimeWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoyagesController : ControllerBase
    {
        private readonly MaritimeDbContext _context;

        public VoyagesController(MaritimeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Voyages
                .Include(v => v.Ship)
                .Include(v => v.DeparturePort)
                .Include(v => v.ArrivalPort)
                .Include(v => v.VisitedCountries)
                .ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var voyage = await _context.Voyages
                .Include(v => v.Ship)
                .Include(v => v.DeparturePort)
                .Include(v => v.ArrivalPort)
                .Include(v => v.VisitedCountries)
                .FirstOrDefaultAsync(v => v.Id == id);

            return voyage == null ? NotFound() : Ok(voyage);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Voyage voyage)
        {
            _context.Voyages.Add(voyage);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = voyage.Id }, voyage);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Voyage updatedVoyage)
        {
            if (id != updatedVoyage.Id) return BadRequest();
            _context.Entry(updatedVoyage).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var voyage = await _context.Voyages.FindAsync(id);
            if (voyage == null) return NotFound();
            _context.Voyages.Remove(voyage);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
