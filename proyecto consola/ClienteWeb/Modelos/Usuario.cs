using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClienteWeb.Modelos
{
    public class Usuario
    {
        public string login { get; set; }
        public string pass { get; set; }
        public string idPais { get; set; }
        public string nombreApellidos { get; set; }
        public string email { get; set; }
        public string fecha { get; set; }
    }
}
