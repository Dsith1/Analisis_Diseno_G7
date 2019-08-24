using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Estudios_G7.Models.ViewModels
{
    public class ListaTareas
    {
        public int id_tarea { get; set; }

        public string enunciado { get; set; }

        public DateTime entrega { get; set; }

        public int curso { get; set; }
    }
}