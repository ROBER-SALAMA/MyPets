using SysMyPets.AccesoADatos;
using SysMyPets.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.LogicaDeNegocio
{
    public class DetalleBL
    {
        public static async Task<int> CrearAsync(Detalle pDetalle)
        {
            return await DetalleDAL.CrearAsync(pDetalle);
        }
        public static async Task<int> ModificarAsync(Detalle pDetalle)
        {

            return await DetalleDAL.ModificarAsync(pDetalle);
        }
        public static async Task<int> EliminarAsync(Detalle pDetalle)
        {
            return await DetalleDAL.EliminarAsync(pDetalle);
        }
        public static async Task<Detalle> ObtenerPorIdAsync(Detalle pDetalle)
        {
            return await DetalleDAL.ObtenerPorIdAsync(pDetalle);
        }
        public static async Task<List<Detalle>> ObtenerTodosAsync()
        {
            return await DetalleDAL.ObtenerTodosAsync();
        }

        public static async Task<List<Detalle>> BuscarAsync(Detalle pDetalle)
        {
            return await DetalleDAL.BuscarAsync(pDetalle);
        }
    }
}
