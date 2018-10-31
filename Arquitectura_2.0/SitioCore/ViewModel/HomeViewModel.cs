using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Modelo;

namespace SitioWeb.ViewModels
{
    public class HomeViewModel
    {
        public List<Moneda> ListaMonedas { get; set; }

        public string Titulo { get; set; }

        public string ImagenMoneda { get; set; }

        public string ID { get; set; }
    }
}
