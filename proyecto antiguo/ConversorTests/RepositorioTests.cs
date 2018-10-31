using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo;
using Repo;

namespace ConversorTests
{
    [TestClass]
    public class RepositorioTests
    {
        [TestMethod]
        public void TestCrearMoneda()
        {


            // Arrange
            var repositorio = new Repositorio();
            var moneda = new Moneda();
            moneda.IdentificadorMoneda = "COP";
            moneda.Nombre = "Pesos Colombianos";

            // Act
            repositorio.CrearMoneda(moneda);

            //Assert
            Moneda monedaResultado = repositorio.ObtenerMoneda("COP");
            Assert.AreEqual(moneda.IdentificadorMoneda, monedaResultado.IdentificadorMoneda);




        }


        [TestMethod]
        public void TestObtenerMonedas()
        {

            // Arrange

            var repositorio = new Repo.Repositorio();
            Moneda monedaEsperada = new Moneda { IdentificadorMoneda = "EUR", Nombre = "Euro" };



            // Act 
            var listaMonedas = repositorio.ObtenerMonedas();
            var monedaObtenida = listaMonedas.FirstOrDefault(p => p.IdentificadorMoneda == "EUR");

            // Assert
            Assert.AreEqual(monedaEsperada.IdentificadorMoneda, monedaObtenida.IdentificadorMoneda);

        }

    }
}
