using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysMyPets.EntidadesDeNegocio;
using SysMyPets.LogicaDeNegocio;

namespace MyPetsWeb.UIAppWebAspCore.Controllers
{
	public class VeterinarioController : Controller
	{
		VeterinarioBL veterinarioBL = new VeterinarioBL();
		// GET: VeterinarioController
		public async Task<IActionResult> Index(Veterinario pVeterinario = null)
		{
			if (pVeterinario == null)
				pVeterinario = new Veterinario();
			if (pVeterinario.Top_Aux == 0)
				pVeterinario.Top_Aux = 10;
			else if (pVeterinario.Top_Aux == -1)
				pVeterinario.Top_Aux = 0;
			var veterinarios = await veterinarioBL.BuscarAsync(pVeterinario);
			ViewBag.Top = pVeterinario.Top_Aux;
			return View(veterinarios);
		}

		// GET: RolController/Details/5
		public async Task<IActionResult> Details(int id)
		{
			var veterinario = await veterinarioBL.ObtenerPorIdAsync(new Veterinario { Id = id });
			return View(veterinario);
		}

		// GET: RolController/Create aca me quedeee
		public IActionResult Create()
		{
			ViewBag.Error = "";
			return View();
		}

		// POST: RolController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(Veterinario pVeterinario)
		{
			try
			{
				int result = await veterinarioBL.CrearAsync(pVeterinario);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View(pVeterinario);
			}
		}

		// GET: RolController/Edit/5
		public async Task<IActionResult> Edit(Veterinario pVeterinario)
		{
			var veterinario = await veterinarioBL.ObtenerPorIdAsync(pVeterinario);
			ViewBag.Error = "";
			return View(veterinario);
		}

		// POST: RolController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, Veterinario pVeterinario)
		{
			try
			{
				int result = await veterinarioBL.ModificarAsync(pVeterinario);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View(pVeterinario);
			}
		}

		// GET: RolController/Delete/5
		public async Task<IActionResult> Delete(Veterinario pVeterinario)
		{
			ViewBag.Error = "";
			var veterinario = await veterinarioBL.ObtenerPorIdAsync(pVeterinario);
			return View(veterinario);
		}

		// POST: RolController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id, Veterinario pVeterinario)
		{
			try
			{
				int result = await veterinarioBL.EliminarAsync(pVeterinario);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				return View(pVeterinario);
			}
		}
	}
}

