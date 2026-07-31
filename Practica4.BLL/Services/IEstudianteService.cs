using Practica4.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica4.BLL.Services
{
    public interface IEstudianteService
    {
        Task<List<EstudianteDTO>> GetAllEstudiantesAsync();
        Task<bool> CreateEstudianteAsync(EstudianteDTO estudiante);
    }
}
