using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerarGUID
{
    class Program
    {
        static void Main(string[] args)
        {
            Guid guid = Guid.NewGuid();
            Console.WriteLine("GUID generado: " + guid);

            string claveSecreta = GenerarClaveSecreta(16); // Puedes especificar la longitud deseada
            Console.WriteLine("Clave secreta generada: " + claveSecreta);

            Console.ReadKey();
        }

        static string GenerarClaveSecreta(int longitud)
        {
            const string caracteresPermitidos = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var rnd = new Random();
            char[] clave = new char[longitud];
            for (int i = 0; i < longitud; i++)
            {
                clave[i] = caracteresPermitidos[rnd.Next(caracteresPermitidos.Length)];
            }
            return new string(clave);
        }
    }
}
