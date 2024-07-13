using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_lib
{
    public class DTO_Ciudadano
    {
        public decimal CUIT { get; set; }

        public decimal DNI { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Prefijo { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Clave { get; set; }

        public string Calle { get; set; }

        public string Altura { get; set; }

        public string Piso { get; set; }

        public string Depto { get; set; }

        public string BarrioCod { get; set; }
        public string Barrio { get; set; }
        public string LocalidadCod { get; set; }

        public string Localidad { get; set; }

        public string ProvinciaCod { get; set; }

        public string Provincia { get; set; }

        public string FechaNacimiento { get; set; }

        public decimal Latitud { get; set; }

        public decimal Longitud { get; set; }

    }
}
