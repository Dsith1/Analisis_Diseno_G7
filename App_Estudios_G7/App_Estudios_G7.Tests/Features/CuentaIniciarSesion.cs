using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBDD;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.NUnit3;

namespace App_Estudios_G7.Tests.Features
{
    [TestFixture]
    [FeatureDescription(
@"In order to support last-in-first-out (LIFO) operations
As an developer
I want to use a stack")]
    [Label("LIFO")]
    class CuentaIniciarSesion
    {
        [Scenario]
        [Label("Ticket-6")]
        [ScenarioCategory(Categories.Sales)]
        public void No_product_in_stock()
        {
            Runner.RunScenario(
                Given_product_is_out_of_stock,
                When_customer_adds_it_to_the_basket,
                Then_the_product_addition_should_be_unsuccessful,
                Then_the_basket_should_not_contain_the_product);
        }
    }
}
