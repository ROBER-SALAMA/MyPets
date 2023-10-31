using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SysMyPets.AccesoADatos;
using SysMyPets.EntidadesDeNegocio;
using SysMyPets.LogicaDeNegocio;

namespace MyPets.WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CitaController : ControllerBase
	{
		private readonly BDContexto _context;

		CitaBL _Bl = new CitaBL();
		public CitaController(BDContexto context)
		{
			_context = context;
		}

		// GET: api/Cita
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Cita>>> GetCita()
		{
			if (_context.Mascota == null)
			{
				return NotFound();
			}
			return await _Bl.ObtenerTodosAsync();
		}

		// GET: api/Cita/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Cita>> GetCita(int id)
		{
			var cita = await _context.Cita.FindAsync(id);

			if (cita == null)
			{
				return NotFound();
			}

			return cita;
		}

		// PUT: api/Mascota/5
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPut("{id}")]
		public async Task<IActionResult> PutCita(int id, Cita cita)
		{
			if (id != cita.Id)
			{
				return BadRequest();
			}

			_context.Entry(cita).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!CitaExists(id))
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

		// POST: api/Cita
		// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
		[HttpPost]
		public async Task<ActionResult<Cita>> PostCita(Cita cita)
		{
			if (cita == null)
			{
				return BadRequest("La cita proporcionada es nula.");
			}

			_context.Cita.Add(cita);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetCita", new { id = cita.Id }, cita);
		}

		// DELETE: api/Mascota/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteCita(int id)
		{
			if (_context.Cita == null)
			{
				return NotFound();
			}
			var cita = await _context.Cita.FindAsync(id);
			if (cita == null)
			{
				return NotFound();
			}

			_context.Cita.Remove(cita);
			await _context.SaveChangesAsync();							

			return NoContent();
		}


		private bool CitaExists(int id)
		{
			return (_context.Mascota?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
