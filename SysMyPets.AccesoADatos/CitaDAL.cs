using Microsoft.EntityFrameworkCore;
using SysMyPets.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysMyPets.AccesoADatos
{
    public class CitaDAL
    {
        public static async Task<int> CrearAsync(Cita pCita)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCita);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Cita pCita)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var Cita = await bdContexto.Cita.FirstOrDefaultAsync(s => s.Id == pCita.Id);
                Cita.IdMascota = pCita.IdMascota;
                Cita.Fecha = pCita.Fecha;
                Cita.Diagnostico = pCita.Diagnostico;
                Cita.Direccion = pCita.Direccion;
                Cita.Propietario = pCita.Propietario;
                Cita.TipoCita = pCita.TipoCita;
                bdContexto.Update(Cita);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Cita pCita)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var Cita = await bdContexto.Cita.FirstOrDefaultAsync(s => s.Id == pCita.Id);
                bdContexto.Cita.Remove(Cita);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Cita> ObtenerPorIdAsync(Cita pCita)
        {
            var Cita = new Cita();
            using (var bdContexto = new BDContexto())
            {
                Cita = await bdContexto.Cita.FirstOrDefaultAsync(s => s.Id == pCita.Id);
            }
            return Cita;
        }
        public static async Task<List<Cita>> ObtenerTodosAsync()
        {
            var citas = new List<Cita>();
            using (var bdContexto = new BDContexto())
            {
                citas = await bdContexto.Cita.ToListAsync();
            }
            return citas;
        }
        internal static IQueryable<Cita> QuerySelect(IQueryable<Cita> pQuery, Cita pCita)
        {
            if (pCita.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCita.Id);
            if (pCita.IdMascota > 0)
                pQuery = pQuery.Where(s => pCita.IdMascota == pCita.IdMascota);
            if (!String.IsNullOrWhiteSpace(pCita.Fecha))
                pQuery = pQuery.Where(s => s.Fecha.Contains(pCita.Fecha));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pCita.Propietario))
                pQuery = pQuery.Where(s => s.Propietario.Contains(pCita.Propietario));
            if (!string.IsNullOrWhiteSpace(pCita.TipoCita))
                pQuery = pQuery.Where(s => s.TipoCita.Contains(pCita.TipoCita));
            if (!string.IsNullOrWhiteSpace(pCita.Direccion))
                pQuery = pQuery.Where(s => s.Direccion.Contains(pCita.Direccion));

            return pQuery;

        }
        public static async Task<List<Cita>> BuscarAsync(Cita pCita)
        {
            var Cita = new List<Cita>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Cita.AsQueryable();
                select = QuerySelect(select, pCita);
                Cita = await select.ToListAsync();
            }
            return Cita;
        }

        public static async Task<List<Cita>> BuscarIncluirMascotaAsync(Cita pCita)
        {
            var citas = new List<Cita>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Cita.AsQueryable();
                select = QuerySelect(select, pCita).Include(s => s.Mascota).AsQueryable();
                citas = await select.ToListAsync();
            }
            return citas;
        }
    }
}
