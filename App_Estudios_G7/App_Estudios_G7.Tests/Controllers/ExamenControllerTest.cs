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
    public class ExamenControllerTest
    {
        [TestMethod]
        public void IndexViewResultIsNotNull()
        {
            // Arrange
            ExamenController controller = new ExamenController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IdDetalleExamenNoValidoResultMensajeError() {
            //Arrange
            ExamenController controller = new ExamenController();
            //Act
            ViewResult result = controller.Details(-1) as ViewResult;
            //Assert
            Assert.IsNotNull(result.ViewBag.MensajeError);
            
        }

        [TestMethod]
        public void IdDetalleExamenNoValidoResultPaginaError()
        {
            //Arrange
            ExamenController controller = new ExamenController();
            //Act
            ViewResult result = controller.Details(-1) as ViewResult;
            //Assert
            Assert.IsNotNull(result);

        }

        // 
        [TestMethod]
        public void IdEditNoValidoResultView() {
            //Arragne
            ExamenController controller = new ExamenController();
            //Act
            ViewResult result = controller.Edit(-5) as ViewResult;
            //Asert 
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IdDeleteNoValidoResultView()
        {
            //Arragne
            ExamenController controller = new ExamenController();
            //Act
            ViewResult result = controller.Delete(-5) as ViewResult;
            //Asert 
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void FechaAnteriorAHoyResultMensajeError()
        {
            //Arrange
            ExamenController controller = new ExamenController();
            //Act
            var examen = new EXAMan() { Fecha = new DateTime(2019, 08, 22) }; 
            ViewResult result = controller.Create(examen) as ViewResult;
            //Assert
            Assert.IsNotNull(result.ViewBag.MessageError);

        }

        [TestMethod]
        public void FechaAnteriorAHoyResultView()
        {
            //Arrange
            ExamenController controller = new ExamenController();
            //Act
            var examen = new EXAMan() { Fecha = new DateTime(2019, 08, 22) };
            ViewResult result = controller.Create(examen) as ViewResult;
            //Assert
            Assert.IsNotNull(result);

        }



    }
}
