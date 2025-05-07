using Microsoft.AspNetCore.Mvc;
using MaritimeWebApp.Server.Data;
using MaritimeWebApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MaritimeWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitedCountriesController : ControllerBase
    {
        private readonly MaritimeDbContext _context;

        public VisitedCountriesController(MaritimeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.VisitedCountries
                .Include(vc => vc.Voyage)
                .ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var country = await _context.VisitedCountries
                .Include(vc => vc.Voyage)
                .FirstOrDefaultAsync(vc => vc.Id == id);

            return country == null ? NotFound() : Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> Create(VisitedCountry country)
        {
            _context.VisitedCountries.Add(country);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = country.Id }, country);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, VisitedCountry updated)
        {
            if (id != updated.Id) return BadRequest();
            _context.Entry(updated).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var country = await _context.VisitedCountries.FindAsync(id);
            if (country == null) return NotFound();
            _context.VisitedCountries.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
