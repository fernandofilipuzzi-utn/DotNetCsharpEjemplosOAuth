using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DTO_lib
{
    public class DTO_Respuesta
    {
        public ResultCode Codigo { get; set; }
        public string Mensaje { get; set; }
        public object Datos { get; set; }
    }

    public enum ResultCode
    {
        Success = 200,
        Error = 500,
        Noauth = 100,
        Notfound = 300,
        Unauthorized = 401,
        Forbidden = 403
    }
}