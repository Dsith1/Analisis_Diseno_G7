using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App_Estudios_G7.Controllers;
using System.Web.Mvc;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    public class UsuariosControllerTest
    {
        [TestMethod]
        public void UsuariosIndexNotNull()
        {
            // Arrange
            USUARIOsController usuario = new USUARIOsController();

            // Act
            ViewResult result = usuario.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void UsuarioDetaislNotNull()
        {
            // Arrange
            USUARIOsController usuario = new USUARIOsController();

            // Act
            ViewResult result = usuario.Details(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void UsuarioCreatelValid()
        {
            // Arrange
            USUARIOsController usuario = new USUARIOsController();

            // Act
            ViewResult result = usuario.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void UsuarioCreateModelNotNull()
        {
            // Arrange
            USUARIOsController usuario = new USUARIOsController();

            // Act
            ViewResult result = usuario.Create(new Models.USUARIO
            { nick = "nuevo",contra="123", nombre_1 = "juan", nombre_2 = "juan", apellido_1="perez", apellido_2 = "perez", edad = 15,correo="algo",rol="normal" }
            ) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
