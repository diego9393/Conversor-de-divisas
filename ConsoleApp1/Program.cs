using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Contexto;
using Modelo;
using Newtonsoft.Json.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Moneda origen: ");
            var idOrigen = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Moneda Destino: ");
            var idDestino = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Cantidad: ");
            var cantidad = Console.ReadLine();
            Console.Clear();

            var valor = new jsonParser();
            valor.from = idOrigen;
            valor.to = idDestino;
            valor.cantidad = "100";
            var resultado = valor.getValor();
        
            Console.WriteLine(resultado);
            Console.WriteLine("Escribiendo en Base de datos");
            var baseDB = new editarDB();
            baseDB.addRegistro(idOrigen, idDestino, resultado);
            Console.WriteLine("Fin");
            Console.ReadKey();
        }
    }

    public class jsonParser
    {
        public string from { get; set; }
        public string to { get; set; }
        public string cantidad { get; set; }
        public string getValor()
        {
            try
            {
                string resultado = "";
                //https://forex.1forge.com/1.0.3/convert?from=USD&to=EUR&quantity=100&api_key=3xVV9NYiGNoskWLSHaQuBWH7ItkxECBQ
                string url = "https://forex.1forge.com/1.0.3/convert?from=" + from + "&to=" + to + "&quantity=" + cantidad + "&api_key=3xVV9NYiGNoskWLSHaQuBWH7ItkxECBQ";
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(url);
                    JObject o = JObject.Parse(json);
                    var valorJson = o["value"];
                    return resultado = valorJson.ToString();
                }
            }
            catch (Exception e)
            {
                return "Error en la conversión";
            }
        }
    }

    public class editarDB
    {
        public void addRegistro(string origen, string destino, string resultado)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MonedaDb>());
            var db = new MonedaDb();

            var historial = new Historial
            {
                IdDestino = destino,
                IdOrigen = origen,
                resultado = destino,
                Fecha = DateTime.Now.ToString()
            };

            /*var moneda = new Moneda
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
            db.Monedas.Add(moneda);*/
            db.Historial.Add(historial);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                var mensaje = ex;
            }
        }

        public void actualizarPais()
        {
            using (var db = new MonedaDb())
            {
                var result = db.Paises.SingleOrDefault(b => b.Id == 4);
                if (result != null)
                {
                    result.IdPais = "FRA";
                    result.Nombre = "Francia";
                    db.SaveChanges();
                }
            }
        }
    }
}
