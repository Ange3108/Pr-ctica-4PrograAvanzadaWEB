using Microsoft.AspNetCore.Mvc;
using Practica4.BLL.DTOs;
using Practica4.BLL.Services;

namespace Practica4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Tags("Estudiantes")]
    public class EstudianteController : Controller
    {
        private readonly IEstudianteService  _estudianteService; 

        public EstudianteController(IEstudianteService estudianteService)
        {
            _estudianteService = estudianteService;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Get: api/Estudiante
        [HttpGet(Name = "GetEstudiantes")]
        [ProducesResponseType(typeof(List<EstudianteDTO>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EstudianteDTO>>> GetPersonas()
        {
            var personas = await _estudianteService.GetAllEstudiantesAsync();
            return Ok(personas);
        }
        // POST: api/Estudiante
        [HttpPost(Name = "RegistrarEstudiante")]
        
        public async Task<ActionResult<EstudianteDTO>>RegistrarEstudiante([FromBody] EstudianteDTO EstudianteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _estudianteService.CreateEstudianteAsync(EstudianteDTO);

            if (!resultado)
            {
                return BadRequest(new { codigo = "C01", mensaje = "No se puede registrar al estudiante. Verifique que cumpla con las reglas de negocio (edad entre 18 y 120 años)." }); //Patron de diseño  
            }

            return Ok(resultado);
        }



    }
}
