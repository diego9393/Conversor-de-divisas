using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Contexto;
using Modelo;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var monedaOrigen = "EUR";
            var monedaDestino = "USD";


            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MonedaDb>());
            var db = new MonedaDb();

            var moneda = new Moneda
            {
                IdentificadorMoneda = "EUR",
                Nombre = "Euro"
            };

            var Pais = new Pais
            {
                IdPais = "UK",
                Nombre = "Reino Unido"
            };

            db.Paises.Add(Pais);
            db.Monedas.Add(moneda);
            try
            {
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                var mensaje = ex;
            }
        }
    }
}
