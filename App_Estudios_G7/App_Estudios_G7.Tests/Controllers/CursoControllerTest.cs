using App_Estudios_G7.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace App_Estudios_G7.Tests.Controllers
{
    [TestClass]
    public class CursoControllerTest
    {
        [TestMethod]
        public void IndexCursoIsNotNull()
        {
            // Arrange
            CursoController curso = new CursoController();

            // Act
            ViewResult result = curso.CursoIndex() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void CreareCursoIsNotNull()
        {
            // Arrange
            CursoController curso = new CursoController();

            // Act
            ViewResult result = curso.CrearCurso() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void CreareCursoModelIsValid()
        {
            // Arrange
            CursoController curso = new CursoController();

            // Act
            ViewResult result = curso.CrearCurso(new Models.CURSO { nombre = "Analisis", creador = 1}) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void CursoDetalleIsNotNull()
        {
            // Arrange
            CursoController curso = new CursoController();

            // Act
            ViewResult result = curso.CursoDetalle("analisis") as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }

}
