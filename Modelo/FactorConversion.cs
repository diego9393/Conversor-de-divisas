namespace Modelo
{
    public class FactorConversion
    {
        public int Id { get; set; }
        public Moneda MonedaOrigen { get; set; }
        public Moneda MonedaDestino { get; set; }
        public decimal Factor { get; set; }

        public FactorConversion(Moneda monedaOrigen,
            Moneda monedaDestino, decimal factor)
        {
            MonedaOrigen = monedaOrigen;
            MonedaDestino = monedaDestino;
            Factor = factor;
        }
    }
}
