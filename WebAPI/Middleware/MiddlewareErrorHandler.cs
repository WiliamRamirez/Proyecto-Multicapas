using System;
using System.Net;
using System.Threading.Tasks;
using Application.ExceptionHandler;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebAPI.Middleware
{
    public class MiddlewareErrorHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MiddlewareErrorHandler> _logger;

        public MiddlewareErrorHandler(RequestDelegate next, ILogger<MiddlewareErrorHandler> logger)
        {
            this._logger = logger;
            this._next = next;
        }
        public async Task Invoke(HttpContext context)
        {

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                await AsynchronousExceptionHandler(context, ex, _logger);
            }
        }

        private async Task AsynchronousExceptionHandler(HttpContext context, Exception ex, ILogger<MiddlewareErrorHandler> logger)
        {
            object errors = null;
            switch (ex)
            {
                case ManejadorError me:
                    logger.LogError(ex, "Manejador Error");
                    errors = me.Errores;
                    context.Response.StatusCode = (int)me.Codigo;
                    break;
                case Exception e:
                    logger.LogError(ex, "Error de Servidor");
                    errors = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            context.Response.ContentType = "application/json";
            if (errors != null)
            {
                var resultados = JsonConvert.SerializeObject(new { errors });
                await context.Response.WriteAsync(resultados);
            }
        }
    }
}