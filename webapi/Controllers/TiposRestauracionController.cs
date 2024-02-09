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
    public class TiposRestauracionController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public TiposRestauracionController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/TiposRestauracion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TiposRestauracion>>> GetTiposRestauracions()
        {
          if (_context.TiposRestauracions == null)
          {
              return NotFound();
          }
            return await _context.TiposRestauracions.ToListAsync();
        }

        // GET: api/TiposRestauracion/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TiposRestauracion>> GetTiposRestauracion(int id)
        {
          if (_context.TiposRestauracions == null)
          {
              return NotFound();
          }
            var tiposRestauracion = await _context.TiposRestauracions.FindAsync(id);

            if (tiposRestauracion == null)
            {
                return NotFound();
            }

            return tiposRestauracion;
        }

        // PUT: api/TiposRestauracion/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTiposRestauracion(int id, TiposRestauracion tiposRestauracion)
        {
            if (id != tiposRestauracion.Id)
            {
                return BadRequest();
            }

            _context.Entry(tiposRestauracion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TiposRestauracionExists(id))
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

        // POST: api/TiposRestauracion
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TiposRestauracion>> PostTiposRestauracion(TiposRestauracion tiposRestauracion)
        {
          if (_context.TiposRestauracions == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.TiposRestauracions'  is null.");
          }
            _context.TiposRestauracions.Add(tiposRestauracion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTiposRestauracion", new { id = tiposRestauracion.Id }, tiposRestauracion);
        }

        // DELETE: api/TiposRestauracion/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTiposRestauracion(int id)
        {
            if (_context.TiposRestauracions == null)
            {
                return NotFound();
            }
            var tiposRestauracion = await _context.TiposRestauracions.FindAsync(id);
            if (tiposRestauracion == null)
            {
                return NotFound();
            }

            _context.TiposRestauracions.Remove(tiposRestauracion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TiposRestauracionExists(int id)
        {
            return (_context.TiposRestauracions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
