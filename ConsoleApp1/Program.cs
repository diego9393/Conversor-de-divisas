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
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MonedaDb>());
            var db = new MonedaDb();
            var moneda = new Moneda
            {
                IdentificadorMoneda = "EUR",
                Nombre = "Euro"
            };

            db.Monedas.Add(moneda);
            db.SaveChanges();

            Console.ReadKey();
        }
    }
}
