using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Historial
    {
        public int Id { get; set; }
        public string IdOrigen { get; set; }
        public string IdDestino { get; set; }
        public string resultado { get; set; }
        public string Fecha { get; set; }
    }
}
