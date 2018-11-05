using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SitioCore.ViewModel
{
    public class ActualizarModel
    {
        public int id { get; set; }
        public decimal Fator { get; set; }
        public int idMonedaOrigen { get; set; }
        public int idMonedaDestino { get; set; }
    }
}
