using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_Estudios_G7.Models.ViewModels
{
    public class CursoViewModel
    {
        [Required]
        [Display(Name ="Nombre")]
        [StringLength(20)]
        public string nombre { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int usuario { get; set; }

    }
}