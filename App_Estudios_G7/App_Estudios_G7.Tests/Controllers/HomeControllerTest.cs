using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App_Estudios_G7;
using App_Estudios_G7.Controllers;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        

        [TestMethod]
        public void Contact()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

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
            bool result = controller.VerificarRegistro("usuario");

            // Assert
            Assert.IsNotNull(result);

        }
    }
}
