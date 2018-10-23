using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json.Linq;

namespace proyecto_final.Controllers
{
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
            catch(Exception e)
            {
                return "Error en la conversión";
            }
        }
    }
}