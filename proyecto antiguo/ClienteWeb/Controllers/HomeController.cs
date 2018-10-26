using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Repo;
using ClienteWeb.Modelos;

namespace ClienteWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepositorio _repositorio;
        public HomeController(IRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            var ListaMonedas = _repositorio.ObtenerMonedas();
            var homeViewModel = new Modelos.HomeViewModel
            {
                Titulo = "Calculin",
                Monedas = ListaMonedas,
                ImagenMonedas = "https://www.worldatlas.com/r/w728-h425-c728x425/upload/d0/91/86/shutterstock-403371907.jpg"
            };

            return View(homeViewModel);
        }
    }
}
