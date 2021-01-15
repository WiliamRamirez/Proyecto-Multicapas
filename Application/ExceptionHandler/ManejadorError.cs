using System;
using System.Net;

namespace Application.ExceptionHandler
{
    public class ManejadorError : Exception
    {
        public HttpStatusCode Codigo { get; }
        public object Errores { get; }


        public ManejadorError(HttpStatusCode codigo, object errores = null)
        {
            this.Codigo = codigo;
            this.Errores = errores;
        }
    }
}