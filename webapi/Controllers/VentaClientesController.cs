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
    public class VentaClientesController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public VentaClientesController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/VentaClientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaCliente>>> GetVentaClientes()
        {
          if (_context.VentaClientes == null)
          {
              return NotFound();
          }
            return await _context.VentaClientes.ToListAsync();
        }

        // GET: api/VentaClientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaCliente>> GetVentaCliente(int id)
        {
          if (_context.VentaClientes == null)
          {
              return NotFound();
          }
            var ventaCliente = await _context.VentaClientes.FindAsync(id);

            if (ventaCliente == null)
            {
                return NotFound();
            }

            return ventaCliente;
        }

        // PUT: api/VentaClientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentaCliente(int id, VentaCliente ventaCliente)
        {
            if (id != ventaCliente.VentaId)
            {
                return BadRequest();
            }

            _context.Entry(ventaCliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaClienteExists(id))
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

        // POST: api/VentaClientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VentaCliente>> PostVentaCliente(VentaCliente ventaCliente)
        {
          if (_context.VentaClientes == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.VentaClientes'  is null.");
          }
            _context.VentaClientes.Add(ventaCliente);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (VentaClienteExists(ventaCliente.VentaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetVentaCliente", new { id = ventaCliente.VentaId }, ventaCliente);
        }

        // DELETE: api/VentaClientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentaCliente(int id)
        {
            if (_context.VentaClientes == null)
            {
                return NotFound();
            }
            var ventaCliente = await _context.VentaClientes.FindAsync(id);
            if (ventaCliente == null)
            {
                return NotFound();
            }

            _context.VentaClientes.Remove(ventaCliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentaClienteExists(int id)
        {
            return (_context.VentaClientes?.Any(e => e.VentaId == id)).GetValueOrDefault();
        }
    }
}
