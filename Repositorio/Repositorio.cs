using System.Collections.Generic;
using System.Linq;
using Infraestructura.Seed;
using Modelo;

namespace Repo
{
    public class Repositorio
    {
        public Repositorio()
        {
            ListaMonedas = new List<Moneda>();
        }
        public List<Moneda> ListaMonedas { get; set; }

        // C - CREATE
        public void CrearMoneda(Moneda moneda)
        {
            Moneda existeMoneda = ObtenerMoneda(moneda.IdentificadorMoneda);
            if (existeMoneda != null) return;
            ListaMonedas.Add(moneda);


        }

        // R - RETRIEVE
        public List<Moneda> ObtenerMonedas()
        {
            ListaMonedas = Seed.CrearListaMonedas();
            return ListaMonedas;
        }

        // U - UPDATE
        public void ActualizarMoneda(string IdMoneda,
            Moneda moneda)
        {
            var buscarMoneda = ObtenerMoneda(IdMoneda);
            buscarMoneda = moneda;

        }


        // D - DELETE

        public void BorrarMoneda(string idMoneda)
        {
            var buscarMoneda = ObtenerMoneda(idMoneda);
            ListaMonedas.Remove(buscarMoneda);
        }

        public Moneda ObtenerMoneda(string IdMoneda)
        {
            return ListaMonedas.FirstOrDefault
                (p => p.IdentificadorMoneda == IdMoneda);


        }

        public List<FactorConversion> ObtenerFactores()
        {
            return Seed.CrearListaFactores();
        }
    }
}
