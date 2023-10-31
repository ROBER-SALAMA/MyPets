
using SysMyPets.EntidadesDeNegocio;
using SysMyPets.AccesoADatos;


namespace SysMyPets.LogicaDeNegocio
{
    public class MascotaBL
    {
        public async Task<int> CrearAsync(Mascota pMascota)
        {
            return await MascotaDAL.CrearAsync(pMascota);
        }
        public async Task<int> ModificarAsync(Mascota pMascota)
        {
            
            return await MascotaDAL.ModificarAsync(pMascota);
        }
        public async Task<int> EliminarAsync(Mascota pMascota)
        {   
            return await MascotaDAL.EliminarAsync(pMascota);
        }
        public async Task<Mascota> ObtenerPorIdAsync(Mascota pMascota)
        {
            return await MascotaDAL.ObtenerPorIdAsync(pMascota);
        }
        public   async Task<List<Mascota>> ObtenerTodosAsync()
        {
            return await MascotaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Mascota>> BuscarAsync(Mascota pMascota)
        {
            return await MascotaDAL.BuscarAsync(pMascota);
        }

        public async Task<List<Mascota>> BuscarIncluirUsuariosAsync(Mascota pMascota)
        {
            return await MascotaDAL.BuscarIncluirUsuariosAsync(pMascota);
        }
    }
}
