using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysMyPets.AccesoADatos;
using SysMyPets.EntidadesDeNegocio;

namespace MyPets.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeterinarioController : ControllerBase
    {
        private readonly BDContexto _context;

        public VeterinarioController(BDContexto context)
        {
            _context = context;
        }

        // GET: api/Veterinario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veterinario>>> Getveterinario()
        {
          if (_context.veterinario == null)
          {
              return NotFound();
          }
            return await _context.veterinario.ToListAsync();
        }

        // GET: api/Veterinario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veterinario>> GetVeterinario(int id)
        {
          if (_context.veterinario == null)
          {
              return NotFound();
          }
            var veterinario = await _context.veterinario.FindAsync(id);

            if (veterinario == null)
            {
                return NotFound();
            }

            return veterinario;
        }

        // PUT: api/Veterinario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeterinario(int id, Veterinario veterinario)
        {
            if (id != veterinario.Id)
            {
                return BadRequest();
            }

            _context.Entry(veterinario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeterinarioExists(id))
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

        // POST: api/Veterinario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veterinario>> PostVeterinario(Veterinario veterinario)
        {
          if (_context.veterinario == null)
          {
              return Problem("Entity set 'BDContexto.veterinario'  is null.");
          }
            _context.veterinario.Add(veterinario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVeterinario", new { id = veterinario.Id }, veterinario);
        }

        // DELETE: api/Veterinario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeterinario(int id)
        {
            if (_context.veterinario == null)
            {
                return NotFound();
            }
            var veterinario = await _context.veterinario.FindAsync(id);
            if (veterinario == null)
            {
                return NotFound();
            }

            _context.veterinario.Remove(veterinario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeterinarioExists(int id)
        {
            return (_context.veterinario?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
