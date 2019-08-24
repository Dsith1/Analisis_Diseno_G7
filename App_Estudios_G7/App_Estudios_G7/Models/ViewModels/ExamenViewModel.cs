using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_Estudios_G7.Models.ViewModels
{
    public class ExamenViewModel
    {
        [Required]
        [Display(Name = "Preguntas")]
        [StringLength(100)]
        public string preguntas { get; set; }

        [Required]
        [Display(Name = "minutos")]
        public int minutos { get; set; }

        [Required]
        [Display(Name = "Fecha")]
        public DateTime fecha { get; set; }
    }
}