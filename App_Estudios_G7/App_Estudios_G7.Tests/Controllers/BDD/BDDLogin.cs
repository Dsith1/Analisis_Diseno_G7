using Xunit;
using App_Estudios_G7.Tests;
using App_Estudios_G7.Models;
using App_Estudios_G7.Controllers;
using System.Web.Mvc;

namespace TestStack.BDDfy
{

    [Story(
        AsA = "Usuario quiero ingresar en el sistema",
        IWant = "debo ingresar mi usuario, contraseña y rol",
        SoThat = "Asi poder ingresar a la pagina principal")]
    public class BDDLogin
    {
        string usuario;
        string password;
        string rol;
        string respuesta;
        CuentaController cuenta;
        void DadoQueIngresoUnUsuarioCorrecto()
        {
            usuario = "admin";
        }

        void YDadoQueIngresoUnPasswordCorrecto()
        {

            password="admin";
        }

        void YDadoQueIngresoUnRolCorrecto()
        {
            rol = "Administrador";
        }

        void CuandoPresionoLogearseValida()
        {
            cuenta = new CuentaController();
            respuesta = cuenta.PruebaInicarSesion(usuario,password,rol);
        }

        void DespuesRetornaUnaRespuestaCorrecta()
        {

            Assert.Equal("Correcto", respuesta);
        }



        [Fact]
        public void EscenarioLoginDatosCorrectos()
        {
            this.Given(_ => DadoQueIngresoUnUsuarioCorrecto())
                .Given(_ => YDadoQueIngresoUnPasswordCorrecto())
                .When(_ => YDadoQueIngresoUnRolCorrecto())
                .Then(_ => CuandoPresionoLogearseValida())
                .Then(_ => DespuesRetornaUnaRespuestaCorrecta())
                .BDDfy();
        }


        void YDadoQueIngresoUnPasswordErroneo()
        {
            password = ":(";
        }

        void DespuesRetornaRespuestaIncorrecta()
        {

            Assert.Equal("Correcto", respuesta);
        }

        [Fact]
        public void EscenarioPasswordUnicoIncorrecto()
        {
            this.Given(_ => DadoQueIngresoUnUsuarioCorrecto())
                .Given(_ => YDadoQueIngresoUnPasswordErroneo())
                .When(_ => YDadoQueIngresoUnRolCorrecto())
                .Then(_ => CuandoPresionoLogearseValida())
                .Then(_ => DespuesRetornaRespuestaIncorrecta())
                .BDDfy();
        }

        void DadoQueIngresoUnrolMaestro()
        {
            rol = "Maestro";
        }

        [Fact]
        public void EscenarioRolCatedraticoCorrecto()
        {
            this.Given(_ => DadoQueIngresoUnUsuarioCorrecto())
                .Given(_ => YDadoQueIngresoUnPasswordCorrecto())
                .When(_ => DadoQueIngresoUnrolMaestro())
                .Then(_ => CuandoPresionoLogearseValida())
                .Then(_ => DespuesRetornaUnaRespuestaCorrecta())
                .BDDfy();
        }

        void DadoQueIngresoUnUsuarioIncorrecto()
        {
            usuario = "no_soy_usuer";
        }

        [Fact]
        public void EscenarioUsuarioIncorrecto()
        {
            this.Given(_ => DadoQueIngresoUnUsuarioIncorrecto())
                .Given(_ => YDadoQueIngresoUnPasswordCorrecto())
                .When(_ => YDadoQueIngresoUnRolCorrecto())
                .Then(_ => CuandoPresionoLogearseValida())
                .Then(_ => DespuesRetornaRespuestaIncorrecta())
                .BDDfy();
        }
    }
}