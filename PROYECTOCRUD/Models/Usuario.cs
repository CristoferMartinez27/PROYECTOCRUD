using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PROYECTOCRUD.Models
{
    [Table("USUARIO", Schema = "UNIVERSITY")]
    public class Usuario
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        [MaxLength(50)]
        [Display(Name = "Usuario")]
        public string USER { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Contraseña")]
        public string PASSWORD { get; set; }
    }
}