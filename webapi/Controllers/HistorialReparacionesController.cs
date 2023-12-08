using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistorialReparacionesController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public HistorialReparacionesController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/HistorialReparaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HistorialReparacione>>> GetHistorialReparaciones()
        {
          if (_context.HistorialReparaciones == null)
          {
              return NotFound();
          }
            return await _context.HistorialReparaciones.ToListAsync();
        }

        // GET: api/HistorialReparaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HistorialReparacione>> GetHistorialReparacione(int id)
        {
          if (_context.HistorialReparaciones == null)
          {
              return NotFound();
          }
            var historialReparacione = await _context.HistorialReparaciones.FindAsync(id);

            if (historialReparacione == null)
            {
                return NotFound();
            }

            return historialReparacione;
        }

        // PUT: api/HistorialReparaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHistorialReparacione(int id, HistorialReparacione historialReparacione)
        {
            if (id != historialReparacione.HistorialId)
            {
                return BadRequest();
            }

            _context.Entry(historialReparacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HistorialReparacioneExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HistorialReparaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HistorialReparacione>> PostHistorialReparacione(HistorialReparacione historialReparacione)
        {
          if (_context.HistorialReparaciones == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.HistorialReparaciones'  is null.");
          }
            _context.HistorialReparaciones.Add(historialReparacione);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HistorialReparacioneExists(historialReparacione.HistorialId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHistorialReparacione", new { id = historialReparacione.HistorialId }, historialReparacione);
        }

        // DELETE: api/HistorialReparaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorialReparacione(int id)
        {
            if (_context.HistorialReparaciones == null)
            {
                return NotFound();
            }
            var historialReparacione = await _context.HistorialReparaciones.FindAsync(id);
            if (historialReparacione == null)
            {
                return NotFound();
            }

            _context.HistorialReparaciones.Remove(historialReparacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HistorialReparacioneExists(int id)
        {
            return (_context.HistorialReparaciones?.Any(e => e.HistorialId == id)).GetValueOrDefault();
        }
    }
}
