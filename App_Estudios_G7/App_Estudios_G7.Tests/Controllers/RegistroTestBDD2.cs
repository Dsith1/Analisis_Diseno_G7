using Xunit;
using App_Estudios_G7.Tests;
using App_Estudios_G7.Models;
using App_Estudios_G7.Controllers;
using System.Web.Mvc;

namespace TestStack.BDDfy.Samples
{
    [Story(
        AsA = "User Needs To Have Access To Platform",
        IWant = "I want to register my account",
        SoThat = "So that I enter my correct information for an account")]
    public class BDDfy_Rocks
    {
        
        USUARIOsController usuario = new USUARIOsController();
        ViewResult result;
        USUARIO user;
        void GivenIEnterMyInformationForRegistry()
        {
            user = new USUARIO()
            { nick = "test12", contra = "123", nombre_1 = "juan", nombre_2 = "juan", apellido_1 = "perez", apellido_2 = "perez", edad = 15, correo = "algo@algo", rol = "normal" };

        }

        void WhenIPressRegisterButton()
        {
            
            result = usuario.Create(user) as ViewResult;
        }

        void ThenUserMustBeRegisteredWhitViewReturn()
        {
            Assert.NotNull(result);
        }


        [Fact]
        public void BDDfy_with_reflective_API()
        {
            this.BDDfy();
        }

        [Fact]
        public void BDDfy_with_fluent_API()
        {
            this.Given(_ => GivenIEnterMyInformationForRegistry())
                .When(_ => WhenIPressRegisterButton())
                .Then(_ => ThenUserMustBeRegisteredWhitViewReturn())
                .BDDfy();
        }
    }
}
