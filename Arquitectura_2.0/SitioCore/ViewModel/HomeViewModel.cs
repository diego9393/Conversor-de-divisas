using System.Collections.Generic;
using Modelo;

namespace SitioWeb.ViewModels
{
    public class HomeViewModel
    {
        public List<Moneda> ListaMonedas { get; set; }

        public string Titulo { get; set; }

        public string ImagenMoneda { get; set; }

        public string IDDestino { get; set; }

        public string IDOrigen { get; set; }

        public decimal Cantidad { get; set; }
    }
}