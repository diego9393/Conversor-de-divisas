using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Contexto;
using Modelo;

namespace Servicio
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service1 : IService1, IDisposable
    {
        readonly MonedaDb _Context = new MonedaDb();

        public void Dispose()
        {
            _Context.Dispose();
        }

        public List<Moneda> getProduct()
        {
            return _Context.Monedas.ToList();
        }
    }
}
