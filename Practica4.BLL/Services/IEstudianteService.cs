using Practica4.BLL.DTOs;

namespace Practica4.BLL.Services
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDTO?>> GetAllEstudiantesAsync();

        Task<EstudianteDTO?> GetEstudianteByIdAsync(int id);

        Task<bool> CreateEstudianteAsync(EstudianteDTO estudiante);

        Task<bool> UpdateEstudianteAsync(EstudianteDTO estudiante);

        Task<bool> DeleteEstudianteAsync(int id);
    }
}