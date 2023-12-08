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
    public class DetalleReparacionController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public DetalleReparacionController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/DetalleReparacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleReparacion>>> GetDetalleReparacions()
        {
          if (_context.DetalleReparacions == null)
          {
              return NotFound();
          }
            return await _context.DetalleReparacions.ToListAsync();
        }

        // GET: api/DetalleReparacion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleReparacion>> GetDetalleReparacion(int id)
        {
          if (_context.DetalleReparacions == null)
          {
              return NotFound();
          }
            var detalleReparacion = await _context.DetalleReparacions.FindAsync(id);

            if (detalleReparacion == null)
            {
                return NotFound();
            }

            return detalleReparacion;
        }

        // PUT: api/DetalleReparacion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleReparacion(int id, DetalleReparacion detalleReparacion)
        {
            if (id != detalleReparacion.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(detalleReparacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleReparacionExists(id))
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

        // POST: api/DetalleReparacion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleReparacion>> PostDetalleReparacion(DetalleReparacion detalleReparacion)
        {
          if (_context.DetalleReparacions == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.DetalleReparacions'  is null.");
          }
            _context.DetalleReparacions.Add(detalleReparacion);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DetalleReparacionExists(detalleReparacion.DetalleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDetalleReparacion", new { id = detalleReparacion.DetalleId }, detalleReparacion);
        }

        // DELETE: api/DetalleReparacion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleReparacion(int id)
        {
            if (_context.DetalleReparacions == null)
            {
                return NotFound();
            }
            var detalleReparacion = await _context.DetalleReparacions.FindAsync(id);
            if (detalleReparacion == null)
            {
                return NotFound();
            }

            _context.DetalleReparacions.Remove(detalleReparacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleReparacionExists(int id)
        {
            return (_context.DetalleReparacions?.Any(e => e.DetalleId == id)).GetValueOrDefault();
        }
    }
}
