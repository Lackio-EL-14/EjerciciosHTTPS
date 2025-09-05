using System.ComponentModel.DataAnnotations;

namespace EjerciciosHttps.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public required string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no es válido")]
        public required string Email { get; set; }
    }
}
