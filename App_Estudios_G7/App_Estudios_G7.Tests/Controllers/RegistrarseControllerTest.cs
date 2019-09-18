using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App_Estudios_G7.Models;
using App_Estudios_G7.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    class RegistrarseControllerTest
    {
        [TestMethod]
        public void LoginUsuarioNoNull()
        {
            // Arrange
            CuentaController controller = new CuentaController();

            // Act
            ViewResult result = controller.Login() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        
        }

        [TestMethod]
        public void RegistrarUsuarioNoNull()
        {
            // Arrange
            CuentaController controller = new CuentaController();

            // Act
            ViewResult result = controller.Registrarse() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void VerificarRegistroNoNull()
        {
            // Arrange
            CuentaController controller = new CuentaController();

            // Act
            bool result = controller.VerificarRegistro();

            // Assert
            Assert.IsNotNull(result);

        }

    }
}
