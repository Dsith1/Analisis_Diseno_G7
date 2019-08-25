using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Estudios_G7.Models.ViewModels
{
    public class ListaActividad
    {
        public int id_actividad { get; set; }

        public int tipo { get; set; }

        public int id_evento { get; set; }

        public int curso { get; set; }
    }
}