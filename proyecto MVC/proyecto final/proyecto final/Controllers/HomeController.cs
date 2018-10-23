using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyecto_final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var valor = new jsonParser();
            valor.from = "USD";
            valor.to = "EUR";
            valor.cantidad = "100";
            var json = valor.getValor();
            ViewBag.Message = json;

            return View();
        }

        [HttpPost]
        public ActionResult getResult(string origen, string destino, string cantidad)
        {
            var valor = new jsonParser();
            valor.from = origen;
            valor.to = destino;
            valor.cantidad = cantidad;
            var json = valor.getValor();
            ViewBag.Message = json;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}