using Store.Customer.API.Errors;
using System.Text.Json;

namespace Store.Customer.API.Middlewares
{
    public class ExceptionMiddlewares
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly ILogger<ExceptionMiddlewares> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionMiddlewares(RequestDelegate requestDelegate, ILogger<ExceptionMiddlewares> logger, IHostEnvironment hostEnvironment)
        {
            _requestDelegate = requestDelegate;
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public async Task InvokeAsync(HttpContext _httpContent)
        {

            try
            {
               await _requestDelegate.Invoke(_httpContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                _httpContent.Response.ContentType = "application/json";
                _httpContent.Response.StatusCode=StatusCodes.Status500InternalServerError;

                var reponse = _hostEnvironment.IsDevelopment() ?
                    new ApiExceptionResponse(StatusCodes.Status500InternalServerError, ex?.StackTrace?.ToString(), ex.Message) :
                    new ApiExceptionResponse(StatusCodes.Status500InternalServerError);
                var json=JsonSerializer.Serialize(reponse);

                await _httpContent.Response.WriteAsync(json);

                


            }
        }
    }
}
