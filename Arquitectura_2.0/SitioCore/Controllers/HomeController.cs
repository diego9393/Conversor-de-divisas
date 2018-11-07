using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepositorioCore;
using SitioCore.Models;
using SitioWeb.ViewModels;
using Modelo;
using Forex;
using ForexQuotes;
using Microsoft.AspNetCore.Authorization;

namespace SitioCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio _repositorio;

        public HomeController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Authorize]
        public IActionResult VerMonedas()
        {
            var listaMonedas = _repositorio.ObtenerMonedas();

            var homeViewModel = new HomeViewModel
            {
                Titulo = "Calculin",
                ListaMonedas = listaMonedas,
                ImagenMoneda = "https://www.worldatlas.com/r/w728-h425-c728x425/upload/d0/91/86/shutterstock-403371907.jpg"
            };

            return View(homeViewModel);
        }

        public IActionResult DetalleMoneda(int id)
        {
            var moneda = _repositorio.BuscarMonedaPorId(id);
            if (moneda == null)
                return NotFound();

            return View(moneda);
        }

        [HttpPost]
        public IActionResult DetalleMoneda(Moneda moneda)
        {
            if (ModelState.IsValid)
            {
                _repositorio.ActualizarMoneda(moneda);
                return RedirectToAction("Index");
            }
            return View(moneda);
        }

        [HttpPost]
        public IActionResult Calcular(string IDOrigen, string IDDestino, decimal cantidad)
        {
            var origenId = _repositorio.buscarMonedaIdMoneda(IDOrigen);
            var destinoId = _repositorio.buscarMonedaIdMoneda(IDDestino);
            var factor = _repositorio.buscarFactor(destinoId.Id, origenId.Id);
            decimal result = _repositorio.calcularMoneda(cantidad, factor.Factor);
            CalcularModel modelo = new CalcularModel
            {
                Resultado = result
            };
            return View(modelo);
        }

        public IActionResult Index()
        {
            //ActualizarFactor();
            return View();
        }

        [Authorize]
        public IActionResult ActualizarFactor()
        {
            var client = new ForexDataClient("3xVV9NYiGNoskWLSHaQuBWH7ItkxECBQ");
            var symbols = client.GetSymbols();
            var quotes = client.GetQuotes(symbols);

            foreach (var symbol in symbols)
            {
                Extraer(symbol, 0);
                Extraer(symbol, 3);
            }

            foreach (var quote in quotes)
            {
                UpdateQuote(quote);
            }
            ViewBag.NumeroMonedas = symbols.Length;
            return View();
        }

        private void UpdateQuote(Quote quote)
        {
            var origen = quote.symbol.Substring(0, 3);
            var destino = quote.symbol.Substring(3, 3);
            var factor = new FactorConversion { IdMonedaOrigen = _repositorio.buscarMonedaIdMoneda(origen).Id, IdMonedaDestino = _repositorio.buscarMonedaIdMoneda(destino).Id, Factor = (decimal)quote.price };
            _repositorio.crearFactor(factor);
        }

        [Authorize]
        public IActionResult ActualizarMonedas()
        {
            var client = new ForexDataClient("3xVV9NYiGNoskWLSHaQuBWH7ItkxECBQ");
            var symbols = client.GetSymbols();
            foreach (var simbolo in symbols)
            {
                Extraer(simbolo, 0);
                Extraer(simbolo, 3);
            }

            var valores = client.GetQuotes(symbols);
            ViewBag.resultado = symbols.Length;

            return View();
        }

        public void Extraer(string symbol, int pos)
        {
            var left = symbol.Substring(pos, 3);
            var moneda = new Moneda { IdentificadorMoneda = left };
            _repositorio.CrearMoneda(moneda);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
