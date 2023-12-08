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
    public class FacturasPagoController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public FacturasPagoController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/FacturasPago
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FacturasPago>>> GetFacturasPagos()
        {
          if (_context.FacturasPagos == null)
          {
              return NotFound();
          }
            return await _context.FacturasPagos.ToListAsync();
        }

        // GET: api/FacturasPago/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturasPago>> GetFacturasPago(int id)
        {
          if (_context.FacturasPagos == null)
          {
              return NotFound();
          }
            var facturasPago = await _context.FacturasPagos.FindAsync(id);

            if (facturasPago == null)
            {
                return NotFound();
            }

            return facturasPago;
        }

        // PUT: api/FacturasPago/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFacturasPago(int id, FacturasPago facturasPago)
        {
            if (id != facturasPago.FacturaId)
            {
                return BadRequest();
            }

            _context.Entry(facturasPago).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturasPagoExists(id))
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

        // POST: api/FacturasPago
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FacturasPago>> PostFacturasPago(FacturasPago facturasPago)
        {
          if (_context.FacturasPagos == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.FacturasPagos'  is null.");
          }
            _context.FacturasPagos.Add(facturasPago);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FacturasPagoExists(facturasPago.FacturaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFacturasPago", new { id = facturasPago.FacturaId }, facturasPago);
        }

        // DELETE: api/FacturasPago/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFacturasPago(int id)
        {
            if (_context.FacturasPagos == null)
            {
                return NotFound();
            }
            var facturasPago = await _context.FacturasPagos.FindAsync(id);
            if (facturasPago == null)
            {
                return NotFound();
            }

            _context.FacturasPagos.Remove(facturasPago);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FacturasPagoExists(int id)
        {
            return (_context.FacturasPagos?.Any(e => e.FacturaId == id)).GetValueOrDefault();
        }
    }
}
