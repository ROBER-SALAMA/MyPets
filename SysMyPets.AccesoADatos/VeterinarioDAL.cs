using Microsoft.EntityFrameworkCore;
using SysMyPets.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SysMyPets.AccesoADatos
{
	public class VeterinarioDAL
	{
		public static async Task<int> CrearAsync(Veterinario pVeterinario)
		{
			int result = 0;
			using (var bdContexto = new BDContexto())
			{
				bdContexto.Add(pVeterinario);
				result = await bdContexto.SaveChangesAsync();
			}
			return result;
		}
		public static async Task<int> ModificarAsync(Veterinario pVeterinario)
		{
			int result = 0;
			using (var bdContexto = new BDContexto())
			{
				var veterinario = await bdContexto.veterinario.FirstOrDefaultAsync(s => s.Id == pVeterinario.Id);
				veterinario.Nombre = pVeterinario.Nombre;
				veterinario.Apellido = pVeterinario.Apellido;
				veterinario.Dui = pVeterinario.Dui;
				bdContexto.Update(veterinario);
				result = await bdContexto.SaveChangesAsync();
			}
			return result;
		}
		public static async Task<int> EliminarAsync(Veterinario pVeterinario)
		{
			int result = 0;
			using (var bdContexto = new BDContexto())
			{
				var veterinario = await bdContexto.veterinario.FirstOrDefaultAsync(s => s.Id == pVeterinario.Id);
				bdContexto.veterinario.Remove(veterinario);
				result = await bdContexto.SaveChangesAsync();
			}
			return result;
		}
		public static async Task<Veterinario> ObtenerPorIdAsync(Veterinario pVeterinario)
		{
			var veterinario = new Veterinario();
			using (var bdContexto = new BDContexto())
			{
				veterinario = await bdContexto.veterinario.FirstOrDefaultAsync(s => s.Id == pVeterinario.Id);
			}
			return veterinario;
		}
		public static async Task<List<Veterinario>> ObtenerTodosAsync()
		{
			var veterinarios = new List<Veterinario>();
			using (var bdContexto = new BDContexto())
			{
				veterinarios = await bdContexto.veterinario.ToListAsync();
			}
			return veterinarios;
		}
		internal static IQueryable<Veterinario> QuerySelect(IQueryable<Veterinario> pQuery, Veterinario pVeterinario)
		{
			if (pVeterinario.Id > 0)
				pQuery = pQuery.Where(s => s.Id == pVeterinario.Id);
			if (!string.IsNullOrWhiteSpace(pVeterinario.Nombre))
				pQuery = pQuery.Where(s => s.Nombre.Contains(pVeterinario.Nombre));
			if (!string.IsNullOrWhiteSpace(pVeterinario.Apellido))
				pQuery = pQuery.Where(s => s.Apellido.Contains(pVeterinario.Apellido));
			if (!string.IsNullOrWhiteSpace(pVeterinario.Dui))
				pQuery = pQuery.Where(s => s.Dui.Contains(pVeterinario.Dui));

			pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
			if (pVeterinario.Top_Aux > 0)
				pQuery = pQuery.Take(pVeterinario.Top_Aux).AsQueryable();
			return pQuery;
		}
		public static async Task<List<Veterinario>> BuscarAsync(Veterinario pVeterinario)
		{
			var veterinarios = new List<Veterinario>();
			using (var bdContexto = new BDContexto())
			{
				var select = bdContexto.veterinario.AsQueryable();
				select = QuerySelect(select, pVeterinario);
				veterinarios = await select.ToListAsync();
			}
			return veterinarios;
		}
	}
}

