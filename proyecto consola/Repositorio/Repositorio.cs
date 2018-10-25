using System.Collections.Generic;
using System.Linq;
using Infraestructura.Seed;
using Modelo;

namespace Repo
{
    public interface IRepositorio
    {
        void CrearMoneda(Moneda moneda);
        void CrearPais(Pais pais);
        void CrearHistorial(Historial historial);
        List<Moneda> ObtenerMonedas();
        void ActualizarMoneda(string IdMoneda, Moneda moneda);
        void BorrarMoneda(string idMoneda);
        Moneda ObtenerMoneda(string IdMoneda);
        Pais obtenerPais(string idPais);
        Historial obtenerHistorial(int idHistorial);
        List<FactorConversion> ObtenerFactores();
    }

    public class repositorioFalso
    {
        
    }

    public class Repositorio
    {
        public Repositorio()
        {
            ListaMonedas = new List<Moneda>();
            ListaPais = new List<Pais>();
            listaHistorial = new List<Historial>();
        }
        public List<Pais> ListaPais { get; set; }
        public List<Moneda> ListaMonedas { get; set; }
        public List<Historial> listaHistorial { get; set; }

        // C - CREATE
        public void CrearMoneda(Moneda moneda)
        {
            Moneda existeMoneda = ObtenerMoneda(moneda.IdentificadorMoneda);
            if (existeMoneda != null) return;
            ListaMonedas.Add(moneda);
        }

        public void CrearPais(Pais pais)
        {
            Pais existePais = obtenerPais(pais.IdPais);
            if (existePais != null) return;
            ListaPais.Add(pais);
        }

        public void CrearHistorial(Historial historial)
        {
            Historial existeHistorial = obtenerHistorial(historial.Id);
            if (existeHistorial != null) return;
            listaHistorial.Add(historial);
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

        public Pais obtenerPais(string idPais)
        {
            return ListaPais.FirstOrDefault
                (x => x.IdPais == idPais);
        }

        public Historial obtenerHistorial(int idHistorial)
        {
            return listaHistorial.FirstOrDefault
                (x => x.Id == idHistorial);
        }

        public List<FactorConversion> ObtenerFactores()
        {
            return Seed.CrearListaFactores();
        }
    }
}
