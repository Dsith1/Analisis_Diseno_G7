using Xunit;
using App_Estudios_G7.Tests;
using App_Estudios_G7.Models;
using App_Estudios_G7.Controllers;
using System.Web.Mvc;

namespace TestStack.BDDfy
{

    [Story(
        AsA = "Catedratico necesito el entorno de un curso",
        IWant = "I want to ingresar un nombre de curso para crearlo",
        SoThat = "So that Ingreso el nombre de curso y el autor del curso")]
    public class BDDCrearCurso
    {
        string curso;
        int autor;
        string respuesta;
        CursoController curso_test;
        void DadoQueIngresoUnNombreCurso()
        {
            curso = "Online CurseUSAC";
        }

        void YDadoQueIngresoUnAutor() {

            autor = 1;
        }

        void CuandoPresionoRegistrarCurso() {
            curso_test = new CursoController();
        }

        void DespuesSeRegistraCursoConDatosIngresados()
        {
            respuesta=curso_test.PruebaCrearCurso(curso,autor);
        }

        void YDespuesRetornaRespuestaCorrecta() {

            Assert.Equal("Correcto",respuesta);
        }

        

        [Fact]
        public void EscenarioTodoCorrecto()
        {
            this.Given(_ => DadoQueIngresoUnNombreCurso())
                .Given(_ => YDadoQueIngresoUnAutor())
                .When(_ => CuandoPresionoRegistrarCurso())
                .Then(_ => DespuesSeRegistraCursoConDatosIngresados())
                .Then(_ => YDespuesRetornaRespuestaCorrecta())
                .BDDfy();
        }


        void YDadoQueIngresoUnAutorErroneo()
        {
            autor = -1;
        }

        void YDespuesRetornaRespuestaInCorrecta()
        {

            Assert.Equal("Incorrecto", respuesta);
        }

        [Fact]
        public void EscenarioNombreAutorIncorrecto()
        {
            this.Given(_ => DadoQueIngresoUnNombreCurso())
                .Given(_ => YDadoQueIngresoUnAutorErroneo())
                .When(_ => CuandoPresionoRegistrarCurso())
                .Then(_ => DespuesSeRegistraCursoConDatosIngresados())
                .Then(_ => YDespuesRetornaRespuestaInCorrecta())
                .BDDfy();
        }

        void DadoQueIngresoUnNombreCursoErroneo() {

            curso = "\";\n$$ññ!!!.........................";
            curso += "\";\n$$ññ!!!.........................";
            curso += "\";\n$$ññ!!!.........................";
            curso += "\";\n$$ññ!!!.........................";
            curso += "\";\n$$ññ!!!.........................";
            curso += "\";\n$$ññ!!!.........................";

        }

        [Fact]
        public void EscenarioNombreCursoIncorrecto()
        {
            this.Given(_ => DadoQueIngresoUnNombreCursoErroneo())
                .Given(_ => YDadoQueIngresoUnAutor())
                .When(_ => CuandoPresionoRegistrarCurso())
                .Then(_ => DespuesSeRegistraCursoConDatosIngresados())
                .Then(_ => YDespuesRetornaRespuestaInCorrecta())
                .BDDfy();
        }

        [Fact]
        public void EscenarioTodoIncorrecto()
        {
            this.Given(_ => DadoQueIngresoUnNombreCursoErroneo())
                .Given(_ => YDadoQueIngresoUnAutorErroneo())
                .When(_ => CuandoPresionoRegistrarCurso())
                .Then(_ => DespuesSeRegistraCursoConDatosIngresados())
                .Then(_ => YDespuesRetornaRespuestaInCorrecta())
                .BDDfy();
        }
    }
}
