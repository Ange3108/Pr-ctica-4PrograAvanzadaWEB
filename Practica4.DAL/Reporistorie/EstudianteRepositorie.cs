using Microsoft.EntityFrameworkCore;
using Practica4.DAL.Data;
using Practica4.DAL.Entities;

namespace Practica4.DAL.Reporistorie
{
    public class EstudianteRepositorie : IEstudianteRepository
    {
        private readonly PracticaDbContext _context;
        public EstudianteRepositorie(PracticaDbContext context)
        {
            _context = context;
        }
        public async Task<bool> RegistrarEstudianteAsync(Estudiante estudiante)
        {
           if (estudiante == null) 
                return false;

            _context.Estudiantes.Add(estudiante);
            await _context.SaveChangesAsync();
            return true;
        }

        public async  Task<List<Estudiante>> GetAllEstudiantesAsync()
        {
            return await _context.Estudiantes.ToListAsync();
        }

        public async Task<Estudiante?> GetEstudianteByIdAsync(int id)
        {
            return await _context.Estudiantes.FindAsync(id);
        }

        public async Task<bool> UpdateEstudianteAsync(Estudiante estudiante)
        {
            var estudianteExistente = await _context.Estudiantes.FindAsync(estudiante.Id);

            if (estudianteExistente == null)
                return false;

            estudianteExistente.Nombre = estudiante.Nombre;
            estudianteExistente.Apellido = estudiante.Apellido;
            estudianteExistente.Edad = estudiante.Edad;
            estudianteExistente.Grado = estudiante.Grado;
            estudianteExistente.Genero = estudiante.Genero;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteEstudianteAsync(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);

            if (estudiante == null)
                return false;

            _context.Estudiantes.Remove(estudiante);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
