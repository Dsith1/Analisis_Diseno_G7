using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App_Estudios_G7;
using App_Estudios_G7.Controllers;
using System.Data;
using App_Estudios_G7.Models;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    public class RegistrarseControllerTest
    {
        [TestMethod]
        public void RegistrarUsuarioNoNull()
        {
            // Arrange
            CuentaController controller = new CuentaController();

            // Act
            ViewResult result = controller.Registrarse(
                new USUARIO {
                    nick ="ni_1",
                    contra = "asdf",
                    nombre_1 ="n_1",
                    nombre_2 ="n_2",
                    apellido_1 = "a_1",
                    apellido_2 = "a_2",
                    edad = 5,
                    correo = "c@g.com",
                    rol = "Estudiante"
                }) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        
        }

        

    }
}
