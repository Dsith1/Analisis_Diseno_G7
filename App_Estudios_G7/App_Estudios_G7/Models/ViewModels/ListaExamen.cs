using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Lista que simula la tabla de examenes
namespace App_Estudios_G7.Models.ViewModels
{
    public class ListaExamen
    {
        public int id_examen { get; set; }
        public string preguntas { get; set; }
        public DateTime fecha { get; set; }
        public int minutos { get; set; }
        private int id_curso { get; set; }
    }
}