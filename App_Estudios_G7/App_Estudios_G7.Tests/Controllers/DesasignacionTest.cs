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

        [TestMethod]
        public void Desasignacion_Conexion_Exitosa()
        {
            Asignaciones asignaciones = new Asignaciones();

            asignaciones.cadena = "data source=LAPTOP-IFGR27P8;initial catalog=Sistema_estudios;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

            bool exito = asignaciones.Abrir_conn();

            Assert.IsTrue(exito);

        }

        [TestMethod]
        public void Desasignacion_Fallida_No_Existe_curso()
        {
            Asignaciones asignaciones = new Asignaciones();

            asignaciones.cadena = "data source=LAPTOP-IFGR27P8;initial catalog=Sistema_estudios;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";

            asignaciones.Abrir_conn();

            int curso = 99;

            bool exito = asignaciones.Verificar_curso(curso);

            Assert.IsFalse(exito);
        }
    }
}
