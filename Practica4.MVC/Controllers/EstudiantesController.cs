using Microsoft.AspNetCore.Mvc;
using Practica4.MVC.Models;
using Practica4.MVC.Services.Estudiantes;

namespace Practica4.MVC.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly IEstudianteService _estudianteService;

        public EstudiantesController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        // Listar estudiantes
        public async Task<IActionResult> Index()
        {
            var estudiantes = await _estudianteService.ObtenerTodosAsync();
            return View(estudiantes);
        }

        // Mostrar formulario de registro
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        // Registrar estudiante
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(EstudianteViewModel estudiante)
        {
            if (!ModelState.IsValid)
                return View(estudiante);

            var resultado = await _estudianteService.CrearAsync(estudiante);

            if (resultado)
            {
                TempData["Success"] = "Estudiante registrado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "No se pudo registrar el estudiante.";
            return View(estudiante);
        }

        // Mostrar formulario de edición
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var estudiante = await _estudianteService.ObtenerPorIdAsync(id);

            if (estudiante == null)
                return NotFound();

            return View(estudiante);
        }

        // Actualizar estudiante
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, EstudianteViewModel estudiante)
        {
            if (!ModelState.IsValid)
                return View(estudiante);

            var resultado = await _estudianteService.EditarAsync(id, estudiante);

            if (resultado)
            {
                TempData["Success"] = "Estudiante actualizado correctamente.";
                return RedirectToAction(nameof(Index));
            }

            TempData["Error"] = "No se pudo actualizar el estudiante.";
            return View(estudiante);
        }

        // Confirmar eliminación
        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            var estudiante = await _estudianteService.ObtenerPorIdAsync(id);

            if (estudiante == null)
                return NotFound();

            return View(estudiante);
        }

        // Eliminar estudiante
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarConfirmed(int id)
        {
            var resultado = await _estudianteService.EliminarAsync(id);

            if (resultado)
            {
                TempData["Success"] = "Estudiante eliminado correctamente.";
            }
            else
            {
                TempData["Error"] = "No se pudo eliminar el estudiante.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}