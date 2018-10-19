using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace Contexto
{
    public class MonedaDb : DbContext
    {
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<FactorConversion> FactoresConverion { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Historial> Historial { get; set; }
    }
}
