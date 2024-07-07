using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceAPIServer.Models
{
    public class DTO_Respuesta
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }

        public DTO_Respuesta()
        {
        }

        public DTO_Respuesta(int codigo, string mensaje, object datos)
        {
            Codigo = codigo;
            Mensaje = mensaje;
            Datos = datos;
        }
    }
}