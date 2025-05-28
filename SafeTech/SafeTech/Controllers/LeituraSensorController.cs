using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeTech.Models;
using SafeTech.Data;

namespace SafeTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeituraSensorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LeituraSensorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LEITURA_SENSOR>>> GetLeituras()
        {
            return await _context.LEITURAS_SENSOR.Include(l => l.SENSOR).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LEITURA_SENSOR>> GetLeitura(int id)
        {
            var leitura = await _context.LEITURAS_SENSOR.Include(l => l.SENSOR).FirstOrDefaultAsync(l => l.ID == id);
            if (leitura == null) return NotFound();
            return leitura;
        }

        [HttpGet("bySensor/{sensorId}")]
        public async Task<ActionResult<IEnumerable<LEITURA_SENSOR>>> GetBySensor(int sensorId)
        {
            return await _context.LEITURAS_SENSOR.Where(l => l.SENSOR_ID == sensorId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<LEITURA_SENSOR>> PostLeitura(LEITURA_SENSOR leitura)
        {
            _context.LEITURAS_SENSOR.Add(leitura);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetLeitura), new { id = leitura.ID }, leitura);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLeitura(int id)
        {
            var leitura = await _context.LEITURAS_SENSOR.FindAsync(id);
            if (leitura == null) return NotFound();
            _context.LEITURAS_SENSOR.Remove(leitura);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

