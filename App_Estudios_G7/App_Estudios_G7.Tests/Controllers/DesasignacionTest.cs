using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App_Estudios_G7;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    public class DesasignacionTest
    {
        [TestMethod]
        public void Desasignacion_Falla_Conexion()
        {            
            Asignaciones asignaciones = new Asignaciones();

            asignaciones.cadena = "Coneccion Fallida";

            bool exito = asignaciones.Abrir_conn();

            Assert.IsFalse(exito);

        }
    }
}
