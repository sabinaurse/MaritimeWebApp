using Microsoft.AspNetCore.Mvc;
using MaritimeWebApp.Server.Data;
using MaritimeWebApp.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MaritimeWebApp.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortsController : ControllerBase
    {
        private readonly MaritimeDbContext _context;

        public PortsController(MaritimeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _context.Ports.ToListAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var port = await _context.Ports.FindAsync(id);
            return port == null ? NotFound() : Ok(port);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Port port)
        {
            _context.Ports.Add(port);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = port.Id }, port);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Port updatedPort)
        {
            if (id != updatedPort.Id) return BadRequest();
            _context.Entry(updatedPort).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var port = await _context.Ports.FindAsync(id);
            if (port == null) return NotFound();
            _context.Ports.Remove(port);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
