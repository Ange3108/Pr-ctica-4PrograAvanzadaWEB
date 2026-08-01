
using System.ComponentModel.DataAnnotations;


namespace Practica4.BLL.DTOs
{
    public class EstudianteDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del estudiante")]
        public string Nombre { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Ingrese el apellido del estudiante")]
        public string Apellido { get; set; } = string.Empty;

        [Range(1, 120, ErrorMessage = "La edad debe ser válida")]
        public int Edad { get; set; }
        
        [Required(ErrorMessage = "Ingrese el grado del estudiante")]
        public string Grado { get; set; }= string.Empty;
        
        [Required(ErrorMessage = "Ingrese el género del estudiante")]
        public string Genero { get; set; }=string.Empty;
    }
}
