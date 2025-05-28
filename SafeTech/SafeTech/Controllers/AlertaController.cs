using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SafeTech.Models;

namespace SafeTech.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AlertaController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ALERTA>>> GetAlertas()
        {
            return await _context.ALERTAS.Include(a => a.ABRIGO).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ALERTA>> GetAlerta(int id)
        {
            var alerta = await _context.ALERTAS.Include(a => a.ABRIGO).FirstOrDefaultAsync(a => a.ID == id);
            if (alerta == null) return NotFound();
            return alerta;
        }

        [HttpGet("byAbrigo/{abrigoId}")]
        public async Task<ActionResult<IEnumerable<ALERTA>>> GetByAbrigo(int abrigoId)
        {
            return await _context.ALERTAS.Where(a => a.ABRIGO_ID == abrigoId).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<ALERTA>> PostAlerta(ALERTA alerta)
        {
            _context.ALERTAS.Add(alerta);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAlerta), new { id = alerta.ID }, alerta);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlerta(int id)
        {
            var alerta = await _context.ALERTAS.FindAsync(id);
            if (alerta == null) return NotFound();
            _context.ALERTAS.Remove(alerta);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}

