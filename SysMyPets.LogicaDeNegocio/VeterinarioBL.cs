using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using SysMyPets.AccesoADatos;
using SysMyPets.EntidadesDeNegocio;

namespace SysMyPets.LogicaDeNegocio
{
	public class VeterinarioBL
	{
		public async Task<int> CrearAsync(Veterinario pVeterinario)
		{
			return await VeterinarioDAL.CrearAsync(pVeterinario);
		}
		public async Task<int> ModificarAsync(Veterinario pVeterinario)
		{
			return await VeterinarioDAL.ModificarAsync(pVeterinario);
		}
		public async Task<int> EliminarAsync(Veterinario pVeterinario)
		{
			return await VeterinarioDAL.EliminarAsync(pVeterinario);
		}
		public async Task<Veterinario> ObtenerPorIdAsync(Veterinario pVeterinario)
		{
			return await VeterinarioDAL.ObtenerPorIdAsync(pVeterinario);
		}
		public async Task<List<Veterinario>> ObtenerTodosAsync()
		{
			return await VeterinarioDAL.ObtenerTodosAsync();
		}
		public async Task<List<Veterinario>> BuscarAsync(Veterinario pVeterinario)
		{
			return await VeterinarioDAL.BuscarAsync(pVeterinario);
		}
	}
}

