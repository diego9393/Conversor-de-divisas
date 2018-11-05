using System.Collections.Generic;
using Modelo;

namespace RepositorioCore
{
    public interface IRepositorio
    {
        decimal calcularMoneda(decimal cantidad, decimal factor);
        List<Moneda> ListaMonedas { get; set; }
        void ActualizarMoneda(Moneda moneda);
        void ActualizarFactor(FactorConversion factor);
        void crearFactor(FactorConversion factor);
        Moneda buscarMonedaIdMoneda(string id);
        void BorrarMoneda(int id);
        Moneda BuscarMonedaPorId(int idMoneda);
        void CrearMoneda(Moneda moneda);
        List<Moneda> GetMonedas();
        List<Moneda> ObtenerMonedas();
        decimal calcularMoneda(string origen, string destino, decimal cantidad, FactorConversion factor);
        FactorConversion buscarFactor(int idDestino, int idOrigen);
    }
}