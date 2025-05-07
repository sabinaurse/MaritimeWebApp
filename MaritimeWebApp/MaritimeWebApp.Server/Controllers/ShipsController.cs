using Microsoft.AspNetCore.Mvc;
using MaritimeWebApp.Server.Data;
using MaritimeWebApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MaritimeWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipsController : ControllerBase
    {
        private readonly MaritimeDbContext _context;

        public ShipsController(MaritimeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Ships.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var ship = await _context.Ships.FindAsync(id);
            return ship == null ? NotFound() : Ok(ship);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ship ship)
        {
            _context.Ships.Add(ship);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = ship.Id }, ship);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ship updatedShip)
        {
            if (id != updatedShip.Id) return BadRequest();
            _context.Entry(updatedShip).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ship = await _context.Ships.FindAsync(id);
            if (ship == null) return NotFound();
            _context.Ships.Remove(ship);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
