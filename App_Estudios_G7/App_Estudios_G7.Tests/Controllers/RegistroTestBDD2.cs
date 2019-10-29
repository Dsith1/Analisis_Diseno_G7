using Xunit;
using App_Estudios_G7.Tests;
using App_Estudios_G7.Models;
using App_Estudios_G7.Controllers;
using System.Web.Mvc;

namespace TestStack.BDDfy
{
    [Story(
        AsA = "User Needs To Have Access To Platform",
        IWant = "I want to register my account",
        SoThat = "So that I enter my correct information for an account")]
    public class RegistroTestBDD2
    {
        
        bool respuesta=true;
        CuentaController cuenta = new CuentaController();
        string nick, contra, nombre_1, nombre_2;
        string apellido_1, apellido_2,edad,correo,rol;

        void GivenIEnterMyInformationForRegister()
        {
            nick = "test102";
            contra = "1234";
            nombre_1 = "Juan";
            nombre_2 = "Jose";
            apellido_1 = "Gonzales";
            apellido_2 = "Perez";
            edad = "21";
            correo = "jose@gmail.com";
            rol = "normal";
        }

        void WhenIPressRegisterButton()
        {
           
            respuesta=cuenta.PruebaRegistrarse(nick,contra,nombre_1,nombre_2,apellido_1,apellido_2,edad,correo,rol);

        }

        void ThenUserMustBeRegisteredReturnTrue()
        {
            Assert.True(respuesta);
        }


        [Fact]
        public void BDDfy_with_reflective_API()
        {
            this.BDDfy();
        }

        /*
        [Fact]
        public void BDDfy_with_fluent_API()
        {
            this.Given(_ => GivenIEnterMyInformationForRegister())
                .When(_ => WhenIPressRegisterButton())
                .Then(_ => ThenUserMustBeRegisteredReturnTrue())
                .BDDfy();
        }
        */
    }
}
