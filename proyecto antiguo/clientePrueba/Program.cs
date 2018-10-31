using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;

namespace clientePrueba
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();
            var msg = proxy.getProduct();
            Console.WriteLine(msg);
            proxy.Close();
            Console.ReadLine();
        }
    }
}
