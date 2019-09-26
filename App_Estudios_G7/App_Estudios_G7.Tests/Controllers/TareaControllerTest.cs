using App_Estudios_G7.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace App_Estudios_G7.Tests.Controllers
{

    [TestClass]
    public class TareaControllerTest
    {
        [TestMethod]
        public void TareaIndexNotNull()
        {
            // Arrange
            TareaController tarea = new TareaController();

            // Act
            ViewResult result = tarea.TareaIndex() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TareaDetaislNotNull()
        {
            // Arrange
            TareaController tarea = new TareaController();

            // Act
            ViewResult result = tarea.TareaDetails(1) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void TareaCreatelValid()
        {
            // Arrange
            TareaController tarea = new TareaController();

            // Act
            ViewResult result = tarea.TareaCreate() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.curso);
        }


        [TestMethod]
        public void TareaCreateModelNotNull()
        {
            // Arrange
            TareaController tarea = new TareaController();

            // Act
            ViewResult result = tarea.TareaCreate(new Models.TAREA
            { Enunciado = "nuevo", Entrega = new DateTime(2019, 08, 22), curso = 1, ponderacion = 0 }
            ) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }



    }
}
