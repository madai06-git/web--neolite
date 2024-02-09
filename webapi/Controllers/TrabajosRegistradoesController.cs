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
    public class TrabajosRegistradoesController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public TrabajosRegistradoesController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/TrabajosRegistradoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrabajosRegistrado>>> GetTrabajosRegistrados()
        {
          if (_context.TrabajosRegistrados == null)
          {
              return NotFound();
          }
            return await _context.TrabajosRegistrados.ToListAsync();
        }

        // GET: api/TrabajosRegistradoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrabajosRegistrado>> GetTrabajosRegistrado(int id)
        {
          if (_context.TrabajosRegistrados == null)
          {
              return NotFound();
          }
            var trabajosRegistrado = await _context.TrabajosRegistrados.FindAsync(id);

            if (trabajosRegistrado == null)
            {
                return NotFound();
            }

            return trabajosRegistrado;
        }

        // PUT: api/TrabajosRegistradoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajosRegistrado(int id, TrabajosRegistrado trabajosRegistrado)
        {
            if (id != trabajosRegistrado.TrabajoId)
            {
                return BadRequest();
            }

            _context.Entry(trabajosRegistrado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajosRegistradoExists(id))
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

        // POST: api/TrabajosRegistradoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrabajosRegistrado>> PostTrabajosRegistrado(TrabajosRegistrado trabajosRegistrado)
        {
          if (_context.TrabajosRegistrados == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.TrabajosRegistrados'  is null.");
          }
            _context.TrabajosRegistrados.Add(trabajosRegistrado);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrabajosRegistradoExists(trabajosRegistrado.TrabajoId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTrabajosRegistrado", new { id = trabajosRegistrado.TrabajoId }, trabajosRegistrado);
        }

        // DELETE: api/TrabajosRegistradoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajosRegistrado(int id)
        {
            if (_context.TrabajosRegistrados == null)
            {
                return NotFound();
            }
            var trabajosRegistrado = await _context.TrabajosRegistrados.FindAsync(id);
            if (trabajosRegistrado == null)
            {
                return NotFound();
            }

            _context.TrabajosRegistrados.Remove(trabajosRegistrado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajosRegistradoExists(int id)
        {
            return (_context.TrabajosRegistrados?.Any(e => e.TrabajoId == id)).GetValueOrDefault();
        }
    }
}
