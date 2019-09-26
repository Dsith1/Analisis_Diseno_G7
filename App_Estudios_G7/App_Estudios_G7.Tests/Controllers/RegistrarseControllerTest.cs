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

        

    }
}
