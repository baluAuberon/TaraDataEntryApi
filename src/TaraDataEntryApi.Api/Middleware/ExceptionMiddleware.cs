using Newtonsoft.Json;
using System.Net;
using TARA.DATAENTRY.API.Exceptions;

namespace TARA.DATAENTRY.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILogger<ExceptionMiddleware> logger;

        public ExceptionMiddleware(RequestDelegate next,ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something went wrong while processing {context.Request.Path}");
                await HandleExceptionAsync(context, ex);
               
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
            var errorDetails = new ErrorDetails
            {
                ErrorType = "Failure",
                ErrorMessage = ex.Message
            };

            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    errorDetails.ErrorType = "Not found";
                    break;
                default:
                    break;
            }
            string response = JsonConvert.SerializeObject(errorDetails);
            context.Response.StatusCode=(int)statusCode;
            return context.Response.WriteAsync(response);
        }
    }
    public class ErrorDetails
    {
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        
    }
}
