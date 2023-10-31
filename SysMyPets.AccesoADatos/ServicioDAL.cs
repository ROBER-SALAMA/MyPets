using Microsoft.EntityFrameworkCore;
using SysMyPets.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.AccesoADatos
{
    public class ServicioDAL
    {
        public static async Task<int> CrearAsync(Servicio pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pServicio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
    
        public static async Task<int> ModificarAsync(Servicio pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                    var servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
                    servicio.IdVeterinario = pServicio.IdVeterinario;
                    servicio.TipoDeServicio = pServicio.TipoDeServicio;
                    bdContexto.Update(servicio);
                    result = await bdContexto.SaveChangesAsync();
             
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Servicio pServicio)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
                bdContexto.Servicio.Remove(servicio);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Servicio> ObtenerPorIdAsync(Servicio pServicio)
        {
            var servicio = new Servicio();
            using (var bdContexto = new BDContexto())
            {
                servicio = await bdContexto.Servicio.FirstOrDefaultAsync(s => s.Id == pServicio.Id);
            }
            return servicio;
        }
        public static async Task<List<Servicio>> ObtenerTodosAsync()
        {
            var servicios = new List<Servicio>();
            using (var bdContexto = new BDContexto())
            {
                servicios = await bdContexto.Servicio.ToListAsync();
            }
            return servicios;
        }
        internal static IQueryable<Servicio> QuerySelect(IQueryable<Servicio> pQuery, Servicio pServicio)
        {
            if (pServicio.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pServicio.Id);
            
            if (pServicio.IdVeterinario > 0)
                pQuery = pQuery.Where(s => s.IdVeterinario == pServicio.IdVeterinario);
            if (!string.IsNullOrWhiteSpace(pServicio.TipoDeServicio))
                pQuery = pQuery.Where(s => s.TipoDeServicio.Contains(pServicio.TipoDeServicio));
            if (pServicio.Top_Aux > 0)
                pQuery = pQuery.Take(pServicio.Top_Aux).AsQueryable();
            return pQuery;
        }
        public static async Task<List<Servicio>> BuscarAsync(Servicio pServicio)
        {
            var Servicios = new List<Servicio>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Servicio.AsQueryable();
                select = QuerySelect(select, pServicio);
                Servicios = await select.ToListAsync();
            }
            return Servicios;
        }

        public static async Task<List<Servicio>> BuscarIncluirVeterinarioAsync(Servicio pServicio)
        {
            var servicios = new List<Servicio>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Servicio.AsQueryable();
                select = QuerySelect(select, pServicio).Include(s => s.Veterinario).AsQueryable();
                servicios = await select.ToListAsync();
            }
            return servicios;
        }

    }
}
