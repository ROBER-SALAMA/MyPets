using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SysMyPets.AccesoADatos;
using SysMyPets.EntidadesDeNegocio;
using SysMyPets.LogicaDeNegocio;

namespace MyPetsWeb.UIAppWebAspCore.Controllers
{
    public class CitaController : Controller
    {
		CitaBL citaBL = new CitaBL();
		MascotaBL mascotaBL = new MascotaBL();
		// GET: CitaController
		public async Task<ActionResult> Index(Cita pCita = null)
		{
			if (pCita == null)
				pCita = new Cita();

			if (pCita.Top_Aux == 0)
				pCita.Top_Aux = 10;
			else if (pCita.Top_Aux == -1)
				pCita.Top_Aux = 0;

			var taskBuscar = citaBL.BuscarIncluirMascotasAsync(pCita);
			var taskObtenerTodosMascota = citaBL.ObtenerTodosAsync(); // Cambié el nombre de la variable

			var citas = await taskBuscar;
			ViewBag.Top = pCita.Top_Aux;
            ViewBag.Citas = await taskObtenerTodosMascota; // Usé la variable correcta

			return View(citas);
		}


		// GET: CitaController/Details/5
		public async Task<ActionResult> Details(int id)
		{
			var cita = await citaBL.ObtenerPorIdAsync(new Cita { Id = id }); 
			cita.Mascota = await mascotaBL.ObtenerPorIdAsync(new Mascota { Id = cita.IdMascota });
			return View(cita);
		}


		// GET: CitaController/Create
		public async Task<ActionResult> Create()
        {
			ViewBag.Mascotas = await mascotaBL.ObtenerTodosAsync();
			ViewBag.Error = "";
			return View();
		}

		// POST: CitaController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create(Cita pcita)
        {
            try
            {
				int result = await citaBL.CrearAsync(pcita);
				return RedirectToAction(nameof(Index));
			}
            catch
            {
				//ViewBag.Error = ex.Message;
				ViewBag.Mascotas = await mascotaBL.ObtenerTodosAsync();
				return View(pcita);
			}
        }

        // GET: CitaController/Edit/5
        public async Task<ActionResult> Edit(Cita pcita)
        {
			var taskObtenerPorId = citaBL.ObtenerPorIdAsync(pcita);
			var taskObtenerTodosMascotas = mascotaBL.ObtenerTodosAsync();
			var cita = await taskObtenerPorId;
			//ViewBag.Roles = await taskObtenerTodosMascotas;
			ViewBag.Mascotas = await taskObtenerTodosMascotas;
            ViewBag.Error = "";
			return View(cita);
		}

        // POST: CitaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Cita pCita)
        {
			try
			{
				int result = await citaBL.ModificarAsync(pCita);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				ViewBag.Macotas = await mascotaBL.ObtenerTodosAsync();
				return View(pCita);
			}
		}

        // GET: CitaController/Delete/5
        public async Task<ActionResult> Delete(Cita pCita)
        {
			var cita = await citaBL.ObtenerPorIdAsync(pCita);
			cita.Mascota = await mascotaBL.ObtenerPorIdAsync(new Mascota { Id = cita.IdMascota });
			ViewBag.Error = "";
			return View(cita);
		}

        // POST: CitaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> Delete(int id, Cita pCita)
		{
			try
			{
				int result = await citaBL.EliminarAsync(pCita);
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
				var cita = await citaBL.ObtenerPorIdAsync(pCita);
				if (cita == null)
					cita = new Cita();
				if (cita.Id > 0)
					cita.Mascota = await mascotaBL.ObtenerPorIdAsync(new Mascota { Id = cita.IdMascota });
				return View(cita);
			}
		}

	}
}
