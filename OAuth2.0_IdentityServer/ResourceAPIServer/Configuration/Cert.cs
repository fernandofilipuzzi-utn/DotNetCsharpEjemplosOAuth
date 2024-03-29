﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ResourceAPIServer.Configuration
{
    public class Cert
    {
        public static X509Certificate2 Load()
        {
            string directorioBase = AppDomain.CurrentDomain.BaseDirectory;
            Console.WriteLine("Directorio Base: " + directorioBase);

            string certPath = Path.Combine(directorioBase, @"Configuration\certificate.pfx");
            string certPassword = "they live";

            X509Certificate2 certificado = new X509Certificate2(certPath, certPassword, X509KeyStorageFlags.MachineKeySet);
            return certificado;
        }
    }
}