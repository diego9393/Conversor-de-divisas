using System.Collections.Generic;
using System.Linq;
using Contexto;
using Modelo;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Forex;
using ForexQuotes;

namespace RepositorioCore
{
    public class Repositorio : IRepositorio
    {
        private readonly MonedaDb _contexto;

        public Repositorio(MonedaDb contexto)
        {
            _contexto = contexto;
            ListaMonedas = new List<Moneda>();
        }

        public void crearFactor(FactorConversion factor)
        {
            var buscar = buscarFactor(factor.IdMonedaDestino, factor.IdMonedaOrigen);

            //buscarMoneda = BuscarMonedaPorId(moneda.Id);
            // Comprueba si ha encontrado la moneda
            if (buscar != null)
            {
                // Ha encontrado la moneda
                // La actualizamos
                ActualizarFactor(factor);
            }
            else
            {
                // No ha encontrado la moneda
                // Creamos la moneda
                _contexto.FactoresConverion.Add(factor);
                _contexto.SaveChanges();
            }
        }

        public decimal calcularMoneda (decimal cantidad, decimal factor)
        {
            var calculo = cantidad * factor;
            return calculo;
        }

        // U - UPDATE
        public void ActualizarFactor(FactorConversion factor)
        {
            var buscar = buscarFactor(factor.IdMonedaDestino, factor.IdMonedaOrigen);
            if (buscar != null)
            {
                buscar.IdMonedaDestino = factor.IdMonedaDestino;
                buscar.IdMonedaOrigen = factor.IdMonedaOrigen;
                buscar.Factor = factor.Factor;
                _contexto.SaveChanges();
            }
        }

        public void ActualizarMoneda(Moneda moneda)
        {
            var buscarMoneda = BuscarMonedaPorId(moneda.Id);
            if (buscarMoneda != null)
            {
                buscarMoneda.Nombre              = moneda.Nombre;
                buscarMoneda.IdentificadorMoneda = moneda.IdentificadorMoneda;
                _contexto.SaveChanges();
            }
        }


        // D - DELETE

        public void BorrarMoneda(int id)
        {
                var buscarMoneda = BuscarMonedaPorId(id);
                if (buscarMoneda == null) return;
                _contexto.Monedas.Remove(buscarMoneda);
                _contexto.SaveChanges();
        }


        public Moneda BuscarMonedaPorId(int IdMoneda)
        {
            return _contexto.Monedas.FirstOrDefault(
                p => p.Id == IdMoneda);
        }

        // C - CREATE
        public FactorConversion buscarFactor (int idDestino, int idOrigen)
        {
            return _contexto.FactoresConverion.FirstOrDefault(p => (p.IdMonedaDestino == idDestino) && (p.IdMonedaOrigen == idOrigen));
        }

        public void CrearFactor(FactorConversion factor)
        {
           var buscar = buscarFactor(factor.IdMonedaDestino, factor.IdMonedaOrigen);

            if (buscar != null)
            {
                // Ha encontrado el factor
                // La actualizamos
                ActualizarFactor(factor);
            }
            else
            {
                // No ha encontrado el factor
                // Creamos la moneda
                _contexto.FactoresConverion.Add(factor);
                _contexto.SaveChanges();
            }
        }

        public Moneda buscarMonedaIdMoneda(string id)
        {
            return _contexto.Monedas.FirstOrDefault(p => p.IdentificadorMoneda == id);
        }

        public void CrearMoneda(Moneda moneda)
        {
            var buscarMoneda = buscarMonedaIdMoneda(moneda.IdentificadorMoneda);

            //buscarMoneda = BuscarMonedaPorId(moneda.Id);
            // Comprueba si ha encontrado la moneda
            if (buscarMoneda != null)
            {
                // Ha encontrado la moneda
                // La actualizamos
                ActualizarMoneda(moneda);
            }
            else
            {
                // No ha encontrado la moneda
                // Creamos la moneda
                _contexto.Monedas.Add(moneda);
                _contexto.SaveChanges();
            }
        }

        public List<Moneda> GetMonedas()
        {
            return new List<Moneda>();
        }

        public List<Moneda> ListaMonedas { get; set; }

        // R - RETRIEVE
        public List<Moneda> ObtenerMonedas()
        {
                return _contexto.Monedas.ToList();
        }

        public decimal calcularMoneda(string origen, string destino, decimal cantidad)
        {
            throw new System.NotImplementedException();
        }

        public decimal calcularMoneda(string origen, string destino, decimal cantidad, FactorConversion factor)
        {
            throw new System.NotImplementedException();
        }
    }
}