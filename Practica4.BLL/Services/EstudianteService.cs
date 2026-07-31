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

            //Si pasa las validaciones, se puede crear el estudiante
           var nuevoEstudiante =estudiante.ToEstudiante();
            nuevoEstudiante.Nombre = estudiante.Nombre;
            nuevoEstudiante.Edad = estudiante.Edad;
            nuevoEstudiante.Apellido = estudiante.Apellido;
            nuevoEstudiante.Grado = estudiante.Grado;
            nuevoEstudiante.Genero = estudiante.Genero;
           return await _estudianteRepository.RegistrarEstudianteAsync(nuevoEstudiante);
        }

        public async Task<List<EstudianteDTO>> GetAllEstudiantesAsync()
        {
  
            var listaEstudiantes = await _estudianteRepository.GetAllEstudiantesAsync();
            return listaEstudiantes.Select(e => e.ToEstudianteDTO()).ToList();
        }
    }
}
