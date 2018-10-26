using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ClienteWeb.Modelos
{
    public class HomeViewModel
    {
        public List<Modelo.Moneda> Monedas { get; set; }
        public string Titulo { get; set; }
        public string ImagenMonedas { get; set; }
    }
}
