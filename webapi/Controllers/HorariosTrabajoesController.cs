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
    public class HorariosTrabajoesController : ControllerBase
    {
        private readonly HospitalCalzadoContext _context;

        public HorariosTrabajoesController(HospitalCalzadoContext context)
        {
            _context = context;
        }

        // GET: api/HorariosTrabajoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HorariosTrabajo>>> GetHorariosTrabajos()
        {
          if (_context.HorariosTrabajos == null)
          {
              return NotFound();
          }
            return await _context.HorariosTrabajos.ToListAsync();
        }

        // GET: api/HorariosTrabajoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HorariosTrabajo>> GetHorariosTrabajo(int id)
        {
          if (_context.HorariosTrabajos == null)
          {
              return NotFound();
          }
            var horariosTrabajo = await _context.HorariosTrabajos.FindAsync(id);

            if (horariosTrabajo == null)
            {
                return NotFound();
            }

            return horariosTrabajo;
        }

        // PUT: api/HorariosTrabajoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorariosTrabajo(int id, HorariosTrabajo horariosTrabajo)
        {
            if (id != horariosTrabajo.HorarioId)
            {
                return BadRequest();
            }

            _context.Entry(horariosTrabajo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorariosTrabajoExists(id))
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

        // POST: api/HorariosTrabajoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HorariosTrabajo>> PostHorariosTrabajo(HorariosTrabajo horariosTrabajo)
        {
          if (_context.HorariosTrabajos == null)
          {
              return Problem("Entity set 'HospitalCalzadoContext.HorariosTrabajos'  is null.");
          }
            _context.HorariosTrabajos.Add(horariosTrabajo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (HorariosTrabajoExists(horariosTrabajo.HorarioId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetHorariosTrabajo", new { id = horariosTrabajo.HorarioId }, horariosTrabajo);
        }

        // DELETE: api/HorariosTrabajoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorariosTrabajo(int id)
        {
            if (_context.HorariosTrabajos == null)
            {
                return NotFound();
            }
            var horariosTrabajo = await _context.HorariosTrabajos.FindAsync(id);
            if (horariosTrabajo == null)
            {
                return NotFound();
            }

            _context.HorariosTrabajos.Remove(horariosTrabajo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorariosTrabajoExists(int id)
        {
            return (_context.HorariosTrabajos?.Any(e => e.HorarioId == id)).GetValueOrDefault();
        }
    }
}
