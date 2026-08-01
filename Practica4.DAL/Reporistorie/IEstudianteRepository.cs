using Practica4.DAL.Entities;

namespace Practica4.DAL.Reporistorie
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetAllEstudiantesAsync();

        Task<bool> RegistrarEstudianteAsync(Estudiante estudiante);

        Task<Estudiante?> GetEstudianteByIdAsync(int id);

        Task<bool> UpdateEstudianteAsync(Estudiante estudiante);

        Task<bool> DeleteEstudianteAsync(int id);
    }
}