using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using App_Estudios_G7.Controllers;
using App_Estudios_G7.Models;
using System.Web;
using System.IO;
using Moq;
using System.Web.Mvc;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    public class PublicacionControllerTest
    {
        [TestMethod]
        public void IndexViewResultIsNotNull()
        {
            // Arrange
            PublicacionController controller = new PublicacionController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IdDetallePublicacionNoValidoResultMensajeError()
        {
            //Arrange
            PublicacionController controller = new PublicacionController();
            //Act
            ViewResult result = controller.Details(-1) as ViewResult;
            //Assert
            Assert.IsNotNull(result.ViewBag.MensajeError);

        }

        [TestMethod]
        public void IdDetallePublicacionNoValidoResultPaginaError()
        {
            //Arrange
            PublicacionController controller = new PublicacionController();
            //Act
            ViewResult result = controller.Details(-1) as ViewResult;
            //Assert
            Assert.IsNotNull(result);

        }

        // 
        [TestMethod]
        public void IdEditNoValidoResultView()
        {
            //Arragne
            PublicacionController controller = new PublicacionController();
            //Act
            ViewResult result = controller.Edit(-5) as ViewResult;
            //Asert 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IdDeleteNoValidoResultView()
        {
            //Arragne
            PublicacionController controller = new PublicacionController();
            //Act
            ViewResult result = controller.Delete(-5) as ViewResult;
            //Asert 
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void Nueva_Publicacion_test()
        {
            //Arrange
            PublicacionController controller = new PublicacionController();
            //Act
            var publicacion = new PUBLICACION() { info = "",curso=1 };
            ViewResult result = controller.Create(publicacion) as ViewResult;
            //Assert
            Assert.IsNotNull(result.ViewBag.MessageError);

        }

    }
}
