﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Modelo;

namespace Servicio
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        //obtener productos
        List<Moneda> getProduct();
    }
}
