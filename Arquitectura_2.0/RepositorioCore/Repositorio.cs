using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Contexto;
//using Infraestructura.Seed;
using Modelo;

namespace Repo
{

    public interface IRepositorio
    {
        List<Moneda> GetMonedas();
            
            
            List<Moneda> ListaMonedas { get; set; }
        Moneda BuscarMonedaPorId(int IdMoneda);

        void CrearMoneda(Moneda moneda);

        List<Moneda> ObtenerMonedas();

        void ActualizarMoneda(Moneda moneda);

        void BorrarMoneda(Moneda moneda);
    }


    public class RepositorioFalso : IRepositorio
    {
        public List<Moneda> GetMonedas()
        {
            throw new System.NotImplementedException();
        }

        public List<Moneda> ListaMonedas { get; set; }
        public Moneda BuscarMonedaPorId(int IdMoneda)
        {
return new Moneda();

        }

        public void CrearMoneda(Moneda moneda)
        {
            
        }

        public List<Moneda> ObtenerMonedas()
        {
            var lista = new List<Moneda>
            {
                new Moneda{IdentificadorMoneda = "EUR", Nombre = "Euros"},
                new Moneda{IdentificadorMoneda = "USD", Nombre = "Dolares"},
                
            };
            return lista;
        }

        public void ActualizarMoneda(Moneda moneda)
        {
            
        }

        public void BorrarMoneda(Moneda moneda)
        {
            
        }
    }

    public class Repositorio : IRepositorio
    {
        private readonly MonedaDb _contexto;
        public Repositorio(MonedaDb contexto)
        {
            _contexto = contexto;
            ListaMonedas = new List<Moneda>();
        }

        public List<Moneda> GetMonedas()
        {
          return new List<Moneda>();
        }

        public List<Moneda> ListaMonedas { get; set; }


        public Moneda BuscarMonedaPorId(int IdMoneda)
        {
            
                return _contexto.Monedas.FirstOrDefault(
                    p => p.Id == IdMoneda);
            
        }


        // C - CREATE

        public void CrearMoneda(Moneda moneda)
        {
        
           using (var context = _contexto)
            {    
                 var buscarMoneda = BuscarMonedaPorId(moneda.Id);
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
                    context.Monedas.Add(moneda);
                    context.SaveChanges();
                }
            }

        }

        // R - RETRIEVE
        public List<Moneda> ObtenerMonedas()
        {
            using (var context =_contexto)
            {
                return context.Monedas.ToList();
            }
        }

        // U - UPDATE
        public void ActualizarMoneda(Moneda moneda)
        {
  
            using (var context = _contexto)
            {
                var buscarMoneda = BuscarMonedaPorId(moneda.Id);
                if (buscarMoneda != null)
                {
                    buscarMoneda.Nombre              = moneda.Nombre;
                    buscarMoneda.IdentificadorMoneda = moneda.IdentificadorMoneda;
                    context.SaveChanges();
                }
            }


        }


        // D - DELETE

        public void BorrarMoneda(Moneda moneda)
        {

            using (var context = _contexto)
            {
                var buscarMoneda = BuscarMonedaPorId(moneda.Id);
                if (buscarMoneda == null)
                {
                    return;
                }
                context.Monedas.Remove(moneda);
                context.SaveChanges();
            }

        }



    }
}
