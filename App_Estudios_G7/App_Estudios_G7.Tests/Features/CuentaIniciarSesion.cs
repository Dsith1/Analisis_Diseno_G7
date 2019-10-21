using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBDD;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using NUnit.Framework;

namespace App_Estudios_G7.Tests.Features
{
    [TestFixture]
    [FeatureDescription(
    @"Scenario: IniciarSesion")]
    [Label("LIFO")]
    class CuentaIniciarSesion
    {
        [Test]
        [Label("Empty")]
        public void Empty_stack()
        {
            //Runner.RunScenario(

                //given => conexion_base_de_datos_Sistema_estudios(),
                //and => Hago_verificaciones_diferentes_roles(),
                //when => datos_correctos(),
                //then => redirije_paginacorrespondiente());
        }
    }
}
