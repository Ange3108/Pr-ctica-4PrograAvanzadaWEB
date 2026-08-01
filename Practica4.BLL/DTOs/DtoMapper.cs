using Practica4.DAL.Entities;

namespace Practica4.BLL.DTOs
{
    public static class DtoMapper
    {
        public static EstudianteDTO? ToEstudianteDTO(this Estudiante estudiante) =>
            estudiante == null ? null : new EstudianteDTO
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Apellido = estudiante.Apellido,
                Edad = estudiante.Edad,
                Grado = estudiante.Grado,
                Genero = estudiante.Genero
            };

        public static Estudiante? ToEstudiante(this EstudianteDTO estudianteDTO) =>
            estudianteDTO == null ? null : new Estudiante
            {
                Id = estudianteDTO.Id,
                Nombre = estudianteDTO.Nombre,
                Apellido = estudianteDTO.Apellido,
                Edad = estudianteDTO.Edad,
                Grado = estudianteDTO.Grado,
                Genero = estudianteDTO.Genero
            };

    }
}
