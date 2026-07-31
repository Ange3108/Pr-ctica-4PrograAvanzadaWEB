using Practica4.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica4.DAL.Reporistorie
{
    public interface IEstudianteRepository
    {
        Task<List<Estudiante>> GetAllEstudiantesAsync();
        Task<bool>RegistrarEstudianteAsync(Estudiante estudiante);
    }
}
