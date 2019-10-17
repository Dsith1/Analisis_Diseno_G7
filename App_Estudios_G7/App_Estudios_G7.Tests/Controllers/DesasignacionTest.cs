using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    public class DesasignacionTest
    {
        [TestMethod]
        public void Desasignacion_Falla_Conexion()
        {
            Asignaciones asignaciones = new Asignaciones();

            bool exito = asignaciones.Abrir_conn();

            Assert.IsFalse(exito);

        }
    }
}
