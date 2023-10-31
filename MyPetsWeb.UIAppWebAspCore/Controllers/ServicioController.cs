using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/********************************/
using SysMyPets.EntidadesDeNegocio;
using SysMyPets.LogicaDeNegocio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace MyPets.UI.AppWebAspCore.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class ServicioController : Controller
    {
        ServicioBL servicioBL = new ServicioBL();
        VeterinarioBL veterinarioBL = new VeterinarioBL(); 
        // GET: ServicioController
        public async Task<IActionResult> Index(Servicio pServicio = null)
        {
            if (pServicio == null)
                pServicio = new Servicio();
            if (pServicio.Top_Aux == 0)
                pServicio.Top_Aux = 10;
            else if (pServicio.Top_Aux == -1)
                pServicio.Top_Aux = 0;
            var taskBuscar = servicioBL.BuscarIncluirVeterinarioAsync(pServicio); 
            var taskObtenerTodosVeterinarios = veterinarioBL.ObtenerTodosAsync();
            var servicios = await taskBuscar;
            ViewBag.Top = pServicio.Top_Aux;
            ViewBag.Veterinarios = await taskObtenerTodosVeterinarios; 
            return View(servicios);
        }

        // GET: UsuarioController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var servicio = await servicioBL.ObtenerPorIdAsync(new Servicio { Id = id });
            servicio.Veterinario = await veterinarioBL.ObtenerPorIdAsync(new Veterinario { Id = servicio.IdVeterinario }); 
            return View(servicio);
        }

        // GET: UsuarioController/Create
        public async Task<IActionResult> Create()
        {
            ViewBag.Veterinarios = await veterinarioBL.ObtenerTodosAsync(); 
            ViewBag.Error = "";
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Servicio pServicio)
        {
            try
            {
                int result = await servicioBL.CrearAsync(pServicio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Veterinarios = await veterinarioBL.ObtenerTodosAsync(); 
                return View(pServicio);
            }
        }

        // GET: UsuarioController/Create
        public async Task<IActionResult> Create2()
        {
            ViewBag.Veterinarios = await veterinarioBL.ObtenerTodosAsync();
            ViewBag.Error = "";
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create2(Servicio pServicio)
        {
            try
            {
                int result = await servicioBL.CrearAsync(pServicio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Veterinarios = await veterinarioBL.ObtenerTodosAsync();
                return View(pServicio);
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<IActionResult> Edit(Servicio pServicio)
        {
            var taskObtenerPorId = servicioBL.ObtenerPorIdAsync(pServicio);
            var taskObtenerTodosVeterinarios = veterinarioBL.ObtenerTodosAsync(); 
            var servicio = await taskObtenerPorId;
            ViewBag.Veterinarios = await taskObtenerTodosVeterinarios; 
            ViewBag.Error = "";
            return View(servicio);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Servicio pServicio)
        {
            try
            {
                int result = await servicioBL.ModificarAsync(pServicio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                ViewBag.Veterinarios = await veterinarioBL.ObtenerTodosAsync(); 
                return View(pServicio);
            }
        }

        // GET: UsuarioController/Delete/5
        public async Task<IActionResult> Delete(Servicio pServicio)
        {
            var servicio = await servicioBL.ObtenerPorIdAsync(pServicio);
            servicio.Veterinario = await veterinarioBL.ObtenerPorIdAsync(new Veterinario { Id = servicio.IdVeterinario }); 
            ViewBag.Error = "";
            return View(servicio);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Servicio pServicio)
        {
            try
            {
                int result = await servicioBL.EliminarAsync(pServicio);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                var servicio = await servicioBL.ObtenerPorIdAsync(pServicio);
                if (servicio == null)
                    servicio = new Servicio();
                if (servicio.Id > 0)
                    servicio.Veterinario = await veterinarioBL.ObtenerPorIdAsync(new Veterinario { Id = servicio.IdVeterinario }); // Cambio de IdCita a IdVeterinario
                return View(servicio);
            }
        }
    }
}
