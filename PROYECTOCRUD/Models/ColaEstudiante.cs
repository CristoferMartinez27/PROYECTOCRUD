using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PROYECTOCRUD.Models
{
    [Table("COLA_ESTUDIANTES", Schema = "UNIVERSITY")]
    public class ColaEstudiante
    {
        [Key]
        [Required]
        [MaxLength(100)]
        [Display(Name = "Carnet")]
        public string CARNET { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nombre")]
        public string NOMBRE { get; set; }

        [Required]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FECHA_NACIMIENTO { get; set; }


        [Display(Name = "Fecha de Registro")]
        public DateTime FECHA_REGISTRO { get; set; }

        [Display(Name = "Fecha de Adicion")]
        public DateTime FECHA_ADICION { get; set; }

    }
}