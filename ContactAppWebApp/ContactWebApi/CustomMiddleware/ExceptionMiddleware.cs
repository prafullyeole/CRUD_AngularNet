using ContactWebApi.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ContactWebApi.CustomMiddleware
{
    /// <summary>
    /// Custom middle ware to handle error from web API
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="next"></param>  
        public ExceptionMiddleware(RequestDelegate next)
        {

            _next = next;
        }

        /// <summary>
        /// Handle HttpContext
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handle Excption Async
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            string errorMessage = "Internal Server Error from the custom middleware.";

            if (exception != null)
            {
                errorMessage = exception.Message;
            }

            return context.Response.WriteAsync(new ErrorDetail()
            {
                StatusCode = context.Response.StatusCode,
                Message = errorMessage
            }.ToString());
        }

      
    }
}
