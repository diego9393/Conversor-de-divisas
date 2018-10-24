using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Contexto;
using Modelo;
using Newtonsoft.Json.Linq;
using Servicio;
using System.ServiceModel;

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
    
            Console.WriteLine("resultado: " + resultado);
            Console.WriteLine("Escribiendo en Base de datos");
            var baseDB = new editarDB();
            baseDB.addRegistro(idOrigen, idDestino, resultado);
            Console.WriteLine("Datos escritos en la base de datos");

            Console.WriteLine("¿Desea ver el histórico?(si/no): ");
            var respuesta = Console.ReadLine();
            if(respuesta == "si")
            {
                baseDB.recogerHistorico();
            }
            else
            {
                Console.WriteLine("Histórico obtenido");
            }

            Console.WriteLine("¿Desea borrar registros?(si/no)");
            var resp = Console.ReadLine();
            if(resp == "si")
            {
                Console.WriteLine("Introduce ID: ");
                var id = 0;
                Int32.TryParse(Console.ReadLine(), out id);
                baseDB.eliminarRegistro(id);
                Console.WriteLine("Registro borrado");
            }
            else
            {
                Console.WriteLine();
            }

            Console.WriteLine("¿Desea actualizar registros?(si/no)");
            var resultadoAc = Console.ReadLine();
            if(resultadoAc == "si")
            {
                Console.WriteLine("Introduce ID: ");
                var id = 0;
                Int32.TryParse(Console.ReadLine(), out id);
                Console.WriteLine("Resultado nuevo: ");
                var resNew = Console.ReadLine();
                baseDB.actualizarPais(id, resNew);
                Console.WriteLine("Registro actualizado");
            }

            Console.WriteLine("Teclee una tecla cualquiera para continuar...");
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
        public void recogerHistorico()
        {
            using (var context = new MonedaDb())
            {
                 foreach (var item in context.Historial)
                {
                    Console.WriteLine(item.Id + ": " + item.IdOrigen + " a " + item.IdDestino + " = " + item.resultado);
                }
            }
        }

        public void eliminarRegistro(int id)
        {
            using (var dbContext = new MonedaDb())
            {
                var rec = dbContext.Historial.FirstOrDefault(x => x.Id == id);
                dbContext.Historial.Remove(rec);
                dbContext.SaveChanges();
            }
        }

        public void addRegistro(string origen, string destino, string resultado)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MonedaDb>());
            var db = new MonedaDb();

            var historial = new Historial
            {
                IdDestino = destino,
                IdOrigen = origen,
                resultado = resultado,
                Fecha = DateTime.Now.ToString()
            };

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

        public void actualizarPais(int idBuscar, string resultadoNuevo)
        {
            using (var db = new MonedaDb())
            {
                var result = db.Historial.SingleOrDefault(b => b.Id == idBuscar);
                if (result != null)
                {
                    result.resultado = resultadoNuevo;
                    db.SaveChanges();
                }
            }
        }
    }
}
