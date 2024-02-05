using System.ComponentModel.DataAnnotations;

namespace BEComentarios.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Creador { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set;}
    }
}
