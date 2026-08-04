using Practica4.MVC.Models;

namespace Practica4.MVC.Services.Estudiantes
{
    public interface IEstudianteService
    {
        Task<List<EstudianteViewModel>> ObtenerTodosAsync();

        Task<EstudianteViewModel?> ObtenerPorIdAsync(int id);

        Task<bool> CrearAsync(EstudianteViewModel estudiante);

        Task<bool> EditarAsync(int id, EstudianteViewModel estudiante);

        Task<bool> EliminarAsync(int id);
    }
}