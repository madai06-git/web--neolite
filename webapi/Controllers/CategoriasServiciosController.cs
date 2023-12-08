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
    public class CategoriasServiciosController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public CategoriasServiciosController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/CategoriasServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriasServicio>>> GetCategoriasServicios()
        {
          if (_context.CategoriasServicios == null)
          {
              return NotFound();
          }
            return await _context.CategoriasServicios.ToListAsync();
        }

        // GET: api/CategoriasServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriasServicio>> GetCategoriasServicio(int id)
        {
          if (_context.CategoriasServicios == null)
          {
              return NotFound();
          }
            var categoriasServicio = await _context.CategoriasServicios.FindAsync(id);

            if (categoriasServicio == null)
            {
                return NotFound();
            }

            return categoriasServicio;
        }

        // PUT: api/CategoriasServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriasServicio(int id, CategoriasServicio categoriasServicio)
        {
            if (id != categoriasServicio.CategoriaId)
            {
                return BadRequest();
            }

            _context.Entry(categoriasServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriasServicioExists(id))
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

        // POST: api/CategoriasServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriasServicio>> PostCategoriasServicio(CategoriasServicio categoriasServicio)
        {
          if (_context.CategoriasServicios == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.CategoriasServicios'  is null.");
          }
            _context.CategoriasServicios.Add(categoriasServicio);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoriasServicioExists(categoriasServicio.CategoriaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategoriasServicio", new { id = categoriasServicio.CategoriaId }, categoriasServicio);
        }

        // DELETE: api/CategoriasServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriasServicio(int id)
        {
            if (_context.CategoriasServicios == null)
            {
                return NotFound();
            }
            var categoriasServicio = await _context.CategoriasServicios.FindAsync(id);
            if (categoriasServicio == null)
            {
                return NotFound();
            }

            _context.CategoriasServicios.Remove(categoriasServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriasServicioExists(int id)
        {
            return (_context.CategoriasServicios?.Any(e => e.CategoriaId == id)).GetValueOrDefault();
        }
    }
}
