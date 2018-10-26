using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

   
        public int IdPais { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Password { get; set; }


        // Propiedades de Navegación
        //[ForeignKey(nameof(IdPais))]
        //public Pais Pais { get; set; }

    }
}
