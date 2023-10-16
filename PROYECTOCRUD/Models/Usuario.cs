using System.ComponentModel.DataAnnotations;

namespace PROYECTOCRUD.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        public bool Estado { get; set; }
    }
}