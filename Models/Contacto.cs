using System.ComponentModel.DataAnnotations;

namespace Udemy.Models
{
    public class Contacto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="El nombre es obligado")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El Telefono es obligado")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El Celular es obligado")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El Email es obligado")]
        public string Email { get; set; }

        public DateTime FechaDeCreacion { get; set; }  
    }
}
