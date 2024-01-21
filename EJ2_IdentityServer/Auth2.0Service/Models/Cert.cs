using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace Auth2._0Service.Models
{
    public class Cert
    {
        public static X509Certificate2 Load()
        {
            // Aquí deberías cargar tu certificado desde donde lo tengas almacenado
            // Puedes cargarlo desde un archivo, desde el almacén de certificados, etc.
            // Asegúrate de ajustar esta parte según tu configuración específica.

            // Ejemplo de carga desde un archivo PFX (asegúrate de ajustar la ruta y la contraseña)
            string certPath = @"F:\repos\repos_utn_dotnet\seguridad\DotNetCsharpEjemplosOAuth\EJ2_roles_permisos\Auth2.0Service\certificados\certificate.pfx";
            string certPassword = "they live";

            return new X509Certificate2(certPath, certPassword);
        }
    }

}