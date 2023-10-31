using Microsoft.EntityFrameworkCore;
using SysMyPets.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.AccesoADatos
{
    public class DetalleDAL
    {
        public static async Task<int> CrearAsync(Detalle pDetalle)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pDetalle);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Detalle pDetalle)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                
                var Detalle = await bdContexto.Detalle.FirstOrDefaultAsync(s => s.IdDetalle == pDetalle.IdDetalle);
                Detalle.Nombre = pDetalle.Nombre;
                Detalle.Descripcion = pDetalle.Descripcion;
                Detalle.Precio = pDetalle.Precio;
                bdContexto.Update(Detalle);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Detalle pDetalle)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var Detalle = await bdContexto.Detalle.FirstOrDefaultAsync(s => s.IdDetalle == pDetalle.IdDetalle);
                bdContexto.Detalle.Remove(Detalle);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Detalle> ObtenerPorIdAsync(Detalle pDetalle)
        {
            var Detalle = new Detalle();
            using (var bdContexto = new BDContexto())
            {
                Detalle = await bdContexto.Detalle.FirstOrDefaultAsync(s => s.IdDetalle == Detalle.IdDetalle);
            }
            return Detalle;
        }
        public static async Task<List<Detalle>> ObtenerTodosAsync()
        {
            var detalles = new List<Detalle>();
            using (var bdContexto = new BDContexto())
            {
                detalles = await bdContexto.Detalle.ToListAsync();
            }
            return detalles;
        }
        internal static IQueryable<Detalle> QuerySelect(IQueryable<Detalle> pQuery, Detalle pDetalle)
        {
            if (pDetalle.IdDetalle > 0)
                pQuery = pQuery.Where(s => s.IdDetalle == pDetalle.IdDetalle);
            if (!String.IsNullOrWhiteSpace(pDetalle.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pDetalle.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.IdDetalle).AsQueryable();

            return pQuery;
            //{
            // if (pCita.Top_Aux > 0)
            // pQuery = pQuery.Take(pCita.Top_Aux).AsQueryable();
            // return pQuery;
            //}
        }
        public static async Task<List<Detalle>> BuscarAsync(Detalle pDetalle)
        {
            var detalles = new List<Detalle>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Detalle.AsQueryable();
                select = QuerySelect(select, pDetalle);
                detalles = await select.ToListAsync();
            }
            return detalles;
        }
    }
}
