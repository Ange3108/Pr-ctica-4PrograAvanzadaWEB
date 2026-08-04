using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Practica4.MVC.Models
{
    public class EstudianteViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el nombre del estudiante.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese el apellido del estudiante.")]
        [StringLength(50, ErrorMessage = "El apellido no puede superar los 50 caracteres.")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; } = string.Empty;

        [Required(ErrorMessage = "Ingrese la edad del estudiante.")]
        [Range(4, 18, ErrorMessage = "La edad debe estar entre 4 y 18 años.")]
        [Display(Name = "Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Ingrese el grado del estudiante.")]
        [StringLength(30, ErrorMessage = "El grado no puede superar los 30 caracteres.")]
        [Display(Name = "Grado")]
        public string Grado { get; set; } = string.Empty;

        [Required(ErrorMessage = "Seleccione el género del estudiante.")]
        [StringLength(30)]
        [Display(Name = "Género")]
        public string Genero { get; set; } = string.Empty;
    }
}
