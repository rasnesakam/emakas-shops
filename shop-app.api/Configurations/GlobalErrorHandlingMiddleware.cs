using shop_app.api.Exceptions;
using System.Diagnostics;
using System.Text.Json;

namespace shop_app.api.Configurations
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly ILogger _logger;
        private readonly RequestDelegate _requestDelegate;

        public GlobalErrorHandlingMiddleware(ILogger logger, RequestDelegate requestDelegate)
        {
            _logger = logger;
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _requestDelegate(context);
            }
            catch (RequestExceptionBase ex)
            {
                await HandleException(context, ex, _logger);
            }
        }

        private static Task HandleException(HttpContext context, RequestExceptionBase requestException, ILogger? logger)
        {
            if (logger != null)
                logger.LogWarning(0, requestException, requestException.Message);
            var exceptionResult = JsonSerializer.Serialize(new { error = requestException.Message, requestException.StackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = requestException.StatusCode;
            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
