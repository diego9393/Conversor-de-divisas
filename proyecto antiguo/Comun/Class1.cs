using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contexto;
using Modelo;
using Newtonsoft.Json.Linq;


namespace Comun
{
    public class Class1
    {
    }

    public class parserJson
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
                    //añadir historial
                    addRegistro(from, to, valorJson.ToString());

                    return resultado = valorJson.ToString();
                }
            }
            catch (Exception e)
            {
                return e.ToString();
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
    }
}
