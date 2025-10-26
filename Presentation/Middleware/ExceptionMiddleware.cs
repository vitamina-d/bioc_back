using Domain.Exceptions;
using System.Diagnostics;

namespace Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        // client → clientException → ExceptionMiddleware, response JSON
        public ExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger(typeof(ExceptionMiddleware));
        }

        public async Task Invoke(HttpContext context)
        {
            //Este id es para simular un ID que viene del FrontEnd/Container
            //Con el cual mantenemos "trace" de toda la acción del usuario
            //Antes de la request
            Guid traceId = Guid.NewGuid();
            _logger.LogDebug($"Request {traceId} iniciada");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //excepciones del client
            try
            {
                await _next(context);
            }
            catch (ClientException ex)
            {
                _logger.LogError(ex, $"ClientException detectada. TraceId={traceId}");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = ex.Code;

                var error = new
                {
                    traceId,
                    code = ex.Code,
                    message = ex.Message
                };

                await context.Response.WriteAsJsonAsync(error);
                return;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error inesperado. TraceId={traceId}");
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                var error = new
                {
                    traceId,
                    code = 500,
                    message = "Error inesperado"
                };

                await context.Response.WriteAsJsonAsync(error);
                return;
            }
            //Despues de la request
            finally
            {
                stopWatch.Stop();

                TimeSpan ts = stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                _logger.LogDebug($"La request {traceId} ha llevado {elapsedTime}");
            }
        }
    }
}
//https://www.netmentor.es/entrada/middleware-vs-filtro