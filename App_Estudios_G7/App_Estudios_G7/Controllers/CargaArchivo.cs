using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App_Estudios_G7.Controllers
{
    public class CargaArchivo
    {
        public Exception Error { get; set; }
        public string Confirmacion { get; set; }

        public void subirArchivo(string ruta, HttpPostedFileBase filetarea)
        {
            try
            {
                filetarea.SaveAs(ruta);
                Confirmacion = "Se guardo la tarea";
                //jenkins = "estoy probando jenkins";
            }
            catch(Exception ex)
            {
                Error = ex;
            }
        }


    }
}
