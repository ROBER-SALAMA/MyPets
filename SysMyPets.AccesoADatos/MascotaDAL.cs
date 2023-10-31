using Microsoft.EntityFrameworkCore;
using SysMyPets.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace SysMyPets.AccesoADatos
{
    public class MascotaDAL
    {
        public static async Task<int> CrearAsync(Mascota pMascota)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pMascota);
                result = await bdContexto.SaveChangesAsync();
            }
            return result; 
        }
        public static async Task<int> ModificarAsync(Mascota pMascota)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var mascota = await bdContexto.Mascota.FirstOrDefaultAsync(s => s.Id == pMascota.Id);

                mascota.IdUsuario = pMascota.IdUsuario;
                mascota.Nombre = pMascota.Nombre;
                mascota.Propietario = pMascota.Propietario;
                mascota.Edad = pMascota.Edad;
                mascota.SenialesParticulares = pMascota.SenialesParticulares;
                bdContexto.Update(mascota);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Mascota pMascota)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var mascota = await bdContexto.Mascota.FirstOrDefaultAsync(s => s.Id == pMascota.Id);
                bdContexto.Mascota.Remove(mascota);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Mascota> ObtenerPorIdAsync(Mascota pMascota)
        {
            var mascota = new Mascota();
            using (var bdContexto = new BDContexto())
            {
                mascota = await bdContexto.Mascota.FirstOrDefaultAsync(s => s.Id == pMascota.Id);
            }
            return mascota;
        }
        public static async Task<List<Mascota>> ObtenerTodosAsync()
        {
            var mascotas = new List<Mascota>();
            using (var bdContexto = new BDContexto())
            {
                mascotas = await bdContexto.Mascota.ToListAsync();
            }
            return mascotas;
        }

        internal static IQueryable<Mascota> QuerySelect(IQueryable<Mascota> pQuery, Mascota pMascota)
        {
            if (pMascota.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMascota.Id);
            if (pMascota.IdUsuario > 0)
                pQuery = pQuery.Where(s => s.IdUsuario == pMascota.IdUsuario);

            if (!string.IsNullOrWhiteSpace(pMascota.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pMascota.Nombre));
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (!string.IsNullOrWhiteSpace(pMascota.Edad))
                pQuery = pQuery.Where(s => s.Edad.Contains(pMascota.Edad));
            if (!string.IsNullOrWhiteSpace(pMascota.Sexo))
                pQuery = pQuery.Where(s => s.Sexo.Contains(pMascota.Sexo));
            if (!string.IsNullOrWhiteSpace(pMascota.Raza))
                pQuery = pQuery.Where(s => s.Raza.Contains(pMascota.Raza));
            if (!string.IsNullOrWhiteSpace(pMascota.SenialesParticulares))
                pQuery = pQuery.Where(s => s.SenialesParticulares.Contains(pMascota.SenialesParticulares));
            if (!string.IsNullOrWhiteSpace(pMascota.Especie))
                pQuery = pQuery.Where(s => s.Especie.Contains(pMascota.Especie));
            if (!string.IsNullOrWhiteSpace(pMascota.Propietario))
                pQuery = pQuery.Where(s => s.Propietario.Contains(pMascota.Propietario));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pMascota.Top_Aux > 0)
                pQuery = pQuery.Take(pMascota.Top_Aux).AsQueryable();
            return pQuery;


        }

        public static async Task<List<Mascota>> BuscarAsync(Mascota pMascota)
        {
            var Mascotas = new List<Mascota>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Mascota.AsQueryable();
                select = QuerySelect(select, pMascota);
                Mascotas = await select.ToListAsync();
            }
            return Mascotas;
        }


         //#endregion
        public static async Task<List<Mascota>> BuscarIncluirUsuariosAsync(Mascota pMascota)
        {
            var mascotas = new List<Mascota>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Mascota.AsQueryable();
                select = QuerySelect(select, pMascota).Include(s => s.Usuario).AsQueryable();
                mascotas = await select.ToListAsync();
            }
            return mascotas;
        }


    }
}


