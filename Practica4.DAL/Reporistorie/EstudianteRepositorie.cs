using Microsoft.EntityFrameworkCore;
using Practica4.DAL.Data;
using Practica4.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
