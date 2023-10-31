
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysMyPets.AccesoADatos;
using SysMyPets.EntidadesDeNegocio;
using SysMyPets.LogicaDeNegocio;

namespace MyPetsWeb.UIAppWebAspCore.Controllers
{
    public class MascotaController : Controller
    {
        MascotaBL mascotaBL = new MascotaBL();
        UsuarioBL usuarioBL = new UsuarioBL();
        // GET: MascotaController
        public async Task<IActionResult> Index(Mascota pMascota = null)
        {
            if (pMascota == null)
                pMascota = new Mascota();
            if (pMascota.Top_Aux == 0)
                pMascota.Top_Aux = 10;
            else if (pMascota.Top_Aux == -1)
                pMascota.Top_Aux = 0;
            var taskBuscar = mascotaBL.BuscarIncluirUsuariosAsync(pMascota);
            var taskObtenerTodosUsuarios = usuarioBL.ObtenerTodosAsync();
            var mascotas = await taskBuscar;
            ViewBag.Top = pMascota.Top_Aux;
            ViewBag.Usuarios = await taskObtenerTodosUsuarios;
            return View(mascotas);
        }

        // GET: MascotaController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var mascota = await mascotaBL.ObtenerPorIdAsync(new Mascota { Id = id });
            mascota.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = mascota.IdUsuario });
            return View(mascota);
        }

        // GET: MascotaController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Usuarios = await usuarioBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: MascotaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Mascota pMascota)
        {
            try
            {
                int result = await mascotaBL.CrearAsync(pMascota);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuarios = await usuarioBL.ObtenerTodosAsync();
                return View(pMascota);
            }
        }

        // GET: MascotaController/Edit/5
        public async Task<ActionResult> Edit(Mascota pMascota)
        {
            var taskObtenerPorId = mascotaBL.ObtenerPorIdAsync(pMascota);
            var taskObtenerTodosUsuarios = usuarioBL.ObtenerTodosAsync();
            var mascota = await taskObtenerPorId;
            ViewBag.Usuarios = await taskObtenerTodosUsuarios;
            ViewBag.Error = "";
            return View(mascota);
        }

        // POST: MascotaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Mascota pMascota)
        {
            try
            {
                int result = await mascotaBL.ModificarAsync(pMascota);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Usuarios = await usuarioBL.ObtenerTodosAsync();
                return View(pMascota);
            }
        }

        // GET: MascotaController/Delete/5
        public async Task<ActionResult> Delete(Mascota pMascota)
        {
            var mascota = await mascotaBL.ObtenerPorIdAsync(pMascota);
            mascota.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = mascota.IdUsuario });
            ViewBag.Error = "";
            return View(mascota);
        }

        // POST: MascotaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Mascota pMascota)
        {
            try
            {
                int result = await mascotaBL.EliminarAsync(pMascota);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var mascota = await mascotaBL.ObtenerPorIdAsync(pMascota);
                if (mascota == null)
                    mascota = new Mascota();
                if (mascota.Id > 0)
                    mascota.Usuario = await usuarioBL.ObtenerPorIdAsync(new Usuario { Id = mascota.IdUsuario });
                return View(mascota);
            }
        }
    }
}
