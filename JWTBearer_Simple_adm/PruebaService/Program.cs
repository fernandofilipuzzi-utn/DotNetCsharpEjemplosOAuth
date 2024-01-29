using JWTBearer_Models.Models;
using JWTBearer_Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaService
{
    class Program
    {
        static void Main(string[] args)
        {
       
            string guid = Guid.NewGuid().ToString();
            string clave = "clave123";
            
            CredencialCliente nuevaCredencial = new CredencialCliente { Guid = guid, Clave = clave };
            JWTBearer_ServicesManager oservice = new JWTBearer_ServicesManager();
            oservice.AgregarCredencial(nuevaCredencial);

            Console.ReadKey();
        }
    }
}
