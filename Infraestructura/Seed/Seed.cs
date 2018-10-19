using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using Modelo;

namespace Infraestructura.Seed
{
    public class Seed
    {
        public static List<Moneda> CrearListaMonedas()
        {

            var monedas = ProcesarArchivo("Monedas.csv");

            List<Moneda> listaMonedas = new List<Moneda>{
                new Moneda{IdentificadorMoneda = "EUR"},
                new Moneda{IdentificadorMoneda = "GBP"},
                new Moneda{IdentificadorMoneda = "USD"},
                new Moneda{IdentificadorMoneda = "INR"},
                new Moneda{IdentificadorMoneda = "AUD"}
            };
            //return listaMonedas;
            return monedas;

        }

        private static List<Moneda> ProcesarArchivo(string monedasCsv)
        {
            var query =

                File.ReadAllLines(monedasCsv)
                    .Skip(1)
                    .Where(l => l.Length > 1)
            //.ToCar();

            //return query.ToList();
            return null;
        }

        public static List<FactorConversion>
            CrearListaFactores()
        {
            var listaMonedasOrigen = CrearListaMonedas();
            var listaMonedasDestino = CrearListaMonedas();
            var listaFactores = new List<FactorConversion>();

            foreach (var monedaOrigen in listaMonedasOrigen)
            {
                foreach (var monedaDestino in listaMonedasDestino)
                {
                    if (monedaOrigen.IdentificadorMoneda == monedaDestino.IdentificadorMoneda)
                    {
                        continue;
                    }

                    var factor = new FactorConversion(monedaOrigen, monedaDestino, ObtenerAleatorio());
                    listaFactores.Add(factor);
                }

            }


            return null;
        }

        public static int ObtenerAleatorio()
        {
            int randomvalue;
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                randomvalue = BitConverter.ToInt32(rno, 0);
            }

            return randomvalue;

        }
    }
}