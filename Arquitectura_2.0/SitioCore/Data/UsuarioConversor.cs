using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SitioCore.Data
{
    public class UsuarioConversor : IdentityUser
    {
        public DateTime FechaNacimiento { get; set; }
        public string Pais { get; set; }
    }
}
