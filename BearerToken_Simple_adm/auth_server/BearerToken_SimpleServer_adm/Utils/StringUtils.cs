using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BearerToken_SimpleServer_adm.Utils
{
    public static class StringUtils
    {
        static Random random = new Random();
        const string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string GenerarClave(int tamaño)
        {
            return new string(Enumerable.Repeat(caracteres, tamaño)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}