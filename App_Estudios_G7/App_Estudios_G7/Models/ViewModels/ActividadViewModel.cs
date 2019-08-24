using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace App_Estudios_G7.Models.ViewModels
{
    public class ActividadViewModel
    {
        [Required]
        [Display(Name = "tipo")]
        public int tipo { get; set; }

        [Required]
        [Display(Name = "id_evento")]
        public int id_evento { get; set; }
    }
}