using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practica4.DAL.Entities
{
    [Table("Estudiante")]
    public class Estudiante
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Edad{ get; set; }
        public string Grado { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;

    }
}
