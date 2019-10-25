using App_Estudios_G7.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Estudios_G7.Tests
{
    [TestClass]
    public class moqPrueba
    {
        [TestMethod]
        public void TestIniciarSesion()
        {
            //creamos objetos dummy
            var mockLog = new Mock<ILog>();
            var validarSesion = new Mock<Sesion>();
            BlogService blog = new BlogService(validarSesion.Object, mockLog.Object);
            Assert.IsNotNull(blog);
        }

        [TestMethod]
        public void TestRegistrarse()
        {
            //creamos objetos dummy
            var mockLog = new Mock<Respuesta>();
            var validarRegistro = new Mock<Registrarse>();
            RegistrarsePrueba blog = new RegistrarsePrueba(validarRegistro.Object, mockLog.Object);
            Assert.IsNotNull(blog);
        }
    }
}
