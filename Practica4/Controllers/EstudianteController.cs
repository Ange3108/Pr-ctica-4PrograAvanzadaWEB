using Microsoft.AspNetCore.Mvc;
using Practica4.BLL.DTOs;
using Practica4.BLL.Services;

namespace Practica4.Controllers
{
    /// <summary>
    /// Gestión de Estudiantes
    ///
    /// Controlador encargado de administrar el listado de estudiantes.
    /// Permite consultar, registrar, actualizar y eliminar estudiantes.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Tags("Estudiantes")]
    public class EstudianteController : ControllerBase
    {
        private readonly IEstudianteService _estudianteService;

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }

        /// <summary>
        /// Obtener todos los estudiantes
        /// </summary>
        /// <returns>Lista de estudiantes</returns>
        /// <response code="200">Operación exitosa</response>
        [HttpGet(Name = "GetEstudiantes")]
        [ProducesResponseType(typeof(List<EstudianteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EstudianteDTO>>> GetEstudiantes()
        {
            var estudiantes = await _estudianteService.GetAllEstudiantesAsync();
            return Ok(estudiantes);
        }

        /// <summary>
        /// Obtener un estudiante por ID
        /// </summary>
        /// <param name="id">Identificador del estudiante</param>
        /// <returns>Estudiante encontrado</returns>
        /// <response code="200">Estudiante encontrado</response>
        /// <response code="404">Estudiante no encontrado</response>
        [HttpGet("{id}", Name = "GetEstudiante")]
        [ProducesResponseType(typeof(EstudianteDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<EstudianteDTO>> GetEstudiante(int id)
        {
            var estudiante = await _estudianteService.GetEstudianteByIdAsync(id);

            if (estudiante == null)
            {
                return NotFound(new
                {
                    codigo = "C02",
                    mensaje = "El estudiante no existe."
                });
            }

            return Ok(estudiante);
        }

        /// <summary>
        /// Registrar un nuevo estudiante
        /// </summary>
        /// <param name="estudianteDTO">Datos del estudiante</param>
        /// <returns>Estudiante registrado</returns>
        /// <response code="201">Estudiante registrado correctamente</response>
        /// <response code="400">Datos inválidos o reglas de negocio incumplidas</response>
        [HttpPost(Name = "RegistrarEstudiante")]
        [ProducesResponseType(typeof(EstudianteDTO), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EstudianteDTO>> RegistrarEstudiante(
            [FromBody] EstudianteDTO estudianteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _estudianteService.CreateEstudianteAsync(estudianteDTO);

            if (!resultado)
            {
                return BadRequest(new
                {
                    codigo = "C01",
                    mensaje = "No se puede registrar el estudiante. Verifique que la edad esté entre 4 y 18 años."
                });
            }

            return CreatedAtAction(
                nameof(GetEstudiante),
                new { id = estudianteDTO.Id },
                estudianteDTO);
        }

        /// <summary>
        /// Actualizar un estudiante existente
        /// </summary>
        /// <param name="id">Identificador del estudiante</param>
        /// <param name="estudiante">Datos actualizados</param>
        /// <returns>Resultado de la operación</returns>
        /// <response code="200">Estudiante actualizado</response>
        /// <response code="400">Datos inválidos</response>
        /// <response code="404">Estudiante no encontrado</response>
        [HttpPut("{id}", Name = "ActualizarEstudiante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateEstudiante(
            int id,
            [FromBody] EstudianteDTO estudiante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != estudiante.Id)
            {
                return BadRequest(new
                {
                    codigo = "C03",
                    mensaje = "El Id de la URL no coincide con el Id enviado."
                });
            }

            var resultado = await _estudianteService.UpdateEstudianteAsync(estudiante);

            if (!resultado)
            {
                return NotFound(new
                {
                    codigo = "C04",
                    mensaje = "No se pudo actualizar el estudiante."
                });
            }

            return Ok(new
            {
                mensaje = "Estudiante actualizado exitosamente."
            });
        }

        /// <summary>
        /// Eliminar un estudiante
        /// </summary>
        /// <param name="id">Identificador del estudiante</param>
        /// <returns>Resultado de la eliminación</returns>
        /// <response code="200">Estudiante eliminado</response>
        /// <response code="404">Estudiante no encontrado</response>
        [HttpDelete("{id}", Name = "EliminarEstudiante")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            var resultado = await _estudianteService.DeleteEstudianteAsync(id);

            if (!resultado)
            {
                return NotFound(new
                {
                    codigo = "C05",
                    mensaje = "El estudiante no existe o no se pudo eliminar."
                });
            }

            return Ok(new
            {
                mensaje = "Estudiante eliminado exitosamente."
            });
        }
    }
}