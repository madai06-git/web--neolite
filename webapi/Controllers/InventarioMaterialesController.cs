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
    public class InventarioMaterialesController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public InventarioMaterialesController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/InventarioMateriales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InventarioMateriale>>> GetInventarioMateriales()
        {
          if (_context.InventarioMateriales == null)
          {
              return NotFound();
          }
            return await _context.InventarioMateriales.ToListAsync();
        }

        // GET: api/InventarioMateriales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InventarioMateriale>> GetInventarioMateriale(int id)
        {
          if (_context.InventarioMateriales == null)
          {
              return NotFound();
          }
            var inventarioMateriale = await _context.InventarioMateriales.FindAsync(id);

            if (inventarioMateriale == null)
            {
                return NotFound();
            }

            return inventarioMateriale;
        }

        // PUT: api/InventarioMateriales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventarioMateriale(int id, InventarioMateriale inventarioMateriale)
        {
            if (id != inventarioMateriale.MaterialId)
            {
                return BadRequest();
            }

            _context.Entry(inventarioMateriale).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioMaterialeExists(id))
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

        // POST: api/InventarioMateriales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InventarioMateriale>> PostInventarioMateriale(InventarioMateriale inventarioMateriale)
        {
          if (_context.InventarioMateriales == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.InventarioMateriales'  is null.");
          }
            _context.InventarioMateriales.Add(inventarioMateriale);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (InventarioMaterialeExists(inventarioMateriale.MaterialId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetInventarioMateriale", new { id = inventarioMateriale.MaterialId }, inventarioMateriale);
        }

        // DELETE: api/InventarioMateriales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventarioMateriale(int id)
        {
            if (_context.InventarioMateriales == null)
            {
                return NotFound();
            }
            var inventarioMateriale = await _context.InventarioMateriales.FindAsync(id);
            if (inventarioMateriale == null)
            {
                return NotFound();
            }

            _context.InventarioMateriales.Remove(inventarioMateriale);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InventarioMaterialeExists(int id)
        {
            return (_context.InventarioMateriales?.Any(e => e.MaterialId == id)).GetValueOrDefault();
        }
    }
}
