using Practica4.BLL.DTOs;
using Practica4.DAL.Reporistorie;


namespace Practica4.BLL.Services
{
    public class EstudianteService : IEstudianteService

    {
        private readonly IEstudianteRepository _estudianteRepository;
        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            _estudianteRepository = estudianteRepository;
        }
        public async Task<bool> CreateEstudianteAsync(EstudianteDTO estudiante)
        {
            //reglas de negocio 
            //Un estudiante no puede tener 
            //una edad menor a 4 años ni mayor a 18 años
            if (estudiante == null)
                return false;
                 

            if(estudiante.Edad < 4 || estudiante.Edad > 18)
            {
                return false;
            }

            //Si pasa las validaciones, se puede crear el estudiante utilizando el Automapper.
            var nuevoEstudiante = estudiante.ToEstudiante();

            if (nuevoEstudiante == null)
                return false;

            return await _estudianteRepository
                .RegistrarEstudianteAsync(nuevoEstudiante);
        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            return await _estudianteRepository
                .DeleteEstudianteAsync(id);
        }

        public async Task<List<EstudianteDTO?>> GetAllEstudiantesAsync()
        {
  
            var listaEstudiantes = await _estudianteRepository.GetAllEstudiantesAsync();
            return listaEstudiantes.Select(e => e.ToEstudianteDTO()).ToList();
        }

        public async Task<EstudianteDTO?> GetEstudianteByIdAsync(int id)
        {
            var estudiante = await _estudianteRepository.GetEstudianteByIdAsync(id);

            return estudiante?.ToEstudianteDTO();
        }

        public async Task<bool> UpdateEstudianteAsync(EstudianteDTO estudiante)
        {
            if (estudiante == null)
                return false;

            if (estudiante.Edad < 4 || estudiante.Edad > 18)
                return false;

            var entidad = estudiante.ToEstudiante();

            if (entidad == null)
                return false;

            return await _estudianteRepository.UpdateEstudianteAsync(entidad);
        }
    }
}
