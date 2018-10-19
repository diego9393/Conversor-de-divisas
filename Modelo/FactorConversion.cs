namespace Modelo
{
    public class FactorConversion
    {
        public int Id { get; set; }
        public Moneda IdMonedaOrigen { get; set; }
        public Moneda IdMonedaDestino { get; set; }
        public decimal Factor { get; set; }

        public Moneda MonedaOrigen { get; set; }
        public Moneda monedaDestino { get; set; }

        public FactorConversion(Moneda monedaOrigen,
            Moneda monedaDestino, decimal factor)
        {
            IdMonedaOrigen = monedaOrigen;
            IdMonedaDestino = monedaDestino;
            Factor = factor;
        }
    }
}
