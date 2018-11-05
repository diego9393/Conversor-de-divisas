using System;
using System.Collections.Generic;
using Modelo;

namespace RepositorioCore
{
    public class RepositorioFalso : IRepositorio
    {
        public void ActualizarFactor(FactorConversion factor)
        {

        }

        public void crearFactor(FactorConversion factor)
        {

        }

        public void ActualizarMoneda(Moneda moneda)
        {
        }

        public void BorrarMoneda(Moneda moneda)
        {
        }

        public Moneda BuscarMonedaPorId(int IdMoneda)
        {
            return new Moneda();
        }

        public void CrearMoneda(Moneda moneda)
        {
        }

        public List<Moneda> GetMonedas()
        {
            throw new NotImplementedException();
        }

        public List<Moneda> ListaMonedas { get; set; }
        List<Moneda> IRepositorio.ListaMonedas { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<Moneda> ObtenerMonedas()
        {
            var lista = new List<Moneda>
            {
                new Moneda {IdentificadorMoneda = "EUR", Nombre = "Euros"},
                new Moneda {IdentificadorMoneda = "USD", Nombre = "Dolares"}
            };
            return lista;
        }

        public decimal calcularMoneda(string origen, string destino, decimal cantidad)
        {
            var resultado = 20;
            return resultado;
        }

        void IRepositorio.ActualizarFactor(FactorConversion factor)
        {
            throw new NotImplementedException();
        }

        void IRepositorio.crearFactor(FactorConversion factor)
        {
            throw new NotFiniteNumberException();
        }

        void IRepositorio.ActualizarMoneda(Moneda moneda)
        {
            throw new NotImplementedException();
        }

        void IRepositorio.BorrarMoneda(int id)
        {
            throw new NotImplementedException();
        }

        Moneda IRepositorio.BuscarMonedaPorId(int idMoneda)
        {
            throw new NotImplementedException();
        }

        void IRepositorio.CrearMoneda(Moneda moneda)
        {
            throw new NotImplementedException();
        }

        List<Moneda> IRepositorio.GetMonedas()
        {
            throw new NotImplementedException();
        }

        List<Moneda> IRepositorio.ObtenerMonedas()
        {
            throw new NotImplementedException();
        }

        decimal IRepositorio.calcularMoneda (decimal cantidad, decimal factor)
        {
            throw new NotImplementedException();
        }

        public Moneda buscarMonedaIdMoneda(string id)
        {
            throw new NotImplementedException();
        }

        public decimal calcularMoneda(decimal cantidad, decimal factor)
        {
            throw new NotImplementedException();
        }

        public decimal calcularMoneda(string origen, string destino, decimal cantidad, FactorConversion factor)
        {
            throw new NotImplementedException();
        }

        public FactorConversion buscarFactor(int idDestino, int idOrigen)
        {
            throw new NotImplementedException();
        }

        public void BorrarMoneda(int id)
        {
            throw new NotImplementedException();
        }
    }
}