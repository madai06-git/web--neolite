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
    public class TrabajosRealizadosController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public TrabajosRealizadosController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/TrabajosRealizados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrabajosRealizado>>> GetTrabajosRealizados()
        {
          if (_context.TrabajosRealizados == null)
          {
              return NotFound();
          }
            return await _context.TrabajosRealizados.ToListAsync();
        }

        // GET: api/TrabajosRealizados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TrabajosRealizado>> GetTrabajosRealizado(int id)
        {
          if (_context.TrabajosRealizados == null)
          {
              return NotFound();
          }
            var trabajosRealizado = await _context.TrabajosRealizados.FindAsync(id);

            if (trabajosRealizado == null)
            {
                return NotFound();
            }

            return trabajosRealizado;
        }

        // PUT: api/TrabajosRealizados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrabajosRealizado(int id, TrabajosRealizado trabajosRealizado)
        {
            if (id != trabajosRealizado.Id)
            {
                return BadRequest();
            }

            _context.Entry(trabajosRealizado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajosRealizadoExists(id))
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

        // POST: api/TrabajosRealizados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TrabajosRealizado>> PostTrabajosRealizado(TrabajosRealizado trabajosRealizado)
        {
          if (_context.TrabajosRealizados == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.TrabajosRealizados'  is null.");
          }
            _context.TrabajosRealizados.Add(trabajosRealizado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrabajosRealizado", new { id = trabajosRealizado.Id }, trabajosRealizado);
        }

        // DELETE: api/TrabajosRealizados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrabajosRealizado(int id)
        {
            if (_context.TrabajosRealizados == null)
            {
                return NotFound();
            }
            var trabajosRealizado = await _context.TrabajosRealizados.FindAsync(id);
            if (trabajosRealizado == null)
            {
                return NotFound();
            }

            _context.TrabajosRealizados.Remove(trabajosRealizado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrabajosRealizadoExists(int id)
        {
            return (_context.TrabajosRealizados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
