using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeTech.Models;
using SafeTech.Data;

namespace SafeTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SensorController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SENSOR>>> GetSensores()
        {
            return await _context.SENSORES.Include(s => s.ABRIGO).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SENSOR>> GetSensor(int id)
        {
            var sensor = await _context.SENSORES.Include(s => s.ABRIGO).FirstOrDefaultAsync(s => s.ID == id);
            if (sensor == null) return NotFound();
            return sensor;
        }

        [HttpGet("byAbrigo/{abrigoId}")]
        public async Task<ActionResult<IEnumerable<SENSOR>>> GetByAbrigo(int abrigoId)
        {
            return await _context.SENSORES.Where(s => s.ABRIGO_ID == abrigoId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<SENSOR>> PostSensor(SENSOR sensor)
        {
            _context.SENSORES.Add(sensor);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSensor), new { id = sensor.ID }, sensor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSensor(int id, SENSOR sensor)
        {
            if (id != sensor.ID) return BadRequest();
            _context.Entry(sensor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSensor(int id)
        {
            var sensor = await _context.SENSORES.FindAsync(id);
            if (sensor == null) return NotFound();
            _context.SENSORES.Remove(sensor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}


