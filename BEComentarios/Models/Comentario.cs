using System.ComponentModel.DataAnnotations;

namespace BEComentarios.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Creador { get; set; }
        public string Texto { get; set; }   
        [Required]
        public DateTime FechaCreacion { get; set;}
    }
}
