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
    public class PuestoController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public PuestoController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/Puesto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Puesto>>> GetPuestos()
        {
          if (_context.Puestos == null)
          {
              return NotFound();
          }
            return await _context.Puestos.ToListAsync();
        }

        // GET: api/Puesto/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Puesto>> GetPuesto(int id)
        {
          if (_context.Puestos == null)
          {
              return NotFound();
          }
            var puesto = await _context.Puestos.FindAsync(id);

            if (puesto == null)
            {
                return NotFound();
            }

            return puesto;
        }

        // PUT: api/Puesto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPuesto(int id, Puesto puesto)
        {
            if (id != puesto.PuestoId)
            {
                return BadRequest();
            }

            _context.Entry(puesto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PuestoExists(id))
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

        // POST: api/Puesto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Puesto>> PostPuesto(Puesto puesto)
        {
          if (_context.Puestos == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.Puestos'  is null.");
          }
            _context.Puestos.Add(puesto);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PuestoExists(puesto.PuestoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPuesto", new { id = puesto.PuestoId }, puesto);
        }

        // DELETE: api/Puesto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePuesto(int id)
        {
            if (_context.Puestos == null)
            {
                return NotFound();
            }
            var puesto = await _context.Puestos.FindAsync(id);
            if (puesto == null)
            {
                return NotFound();
            }

            _context.Puestos.Remove(puesto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PuestoExists(int id)
        {
            return (_context.Puestos?.Any(e => e.PuestoId == id)).GetValueOrDefault();
        }
    }
}
