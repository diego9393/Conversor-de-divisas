using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repo;
using SitioCore.Models;
using SitioWeb.ViewModels;

namespace SitioCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio _repositorio;

        public HomeController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

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

        public IActionResult Index()
        {
            return View();
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
