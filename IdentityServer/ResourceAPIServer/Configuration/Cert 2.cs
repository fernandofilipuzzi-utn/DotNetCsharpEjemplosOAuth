using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ResourceAPIServer.Configuration
{
    public class Cert2
    {
        public static X509Certificate2 Load()
        {
            var assembly = typeof(Cert2).Assembly;
            using (var stream = assembly.GetManifestResourceStream("ResourceAPIServer.Configuration.certificate.pfx"))
            {
                return new X509Certificate2(ReadStream(stream), "they live");
            }
        }

        private static byte[] ReadStream(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}