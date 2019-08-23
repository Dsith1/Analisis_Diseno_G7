using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Estudios_G7.Models.ViewModels
{
    public class ListaCursos
    {
        public int id_curso { get; set; }
        public string nombre { get; set; }
        public string nombre_1 { get; set; }
        public string apellido_1 { get; set; }
        public string getAutor() { return nombre_1 + " " + apellido_1; }
    }
}