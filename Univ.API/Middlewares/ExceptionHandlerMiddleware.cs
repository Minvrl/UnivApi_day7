using Univ.Service.Exceptions;

namespace Univ.API.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                 var msg = ex.Message;  
                 var errors = new List<RestExceptionError>();
                context.Response.StatusCode = 500;
                if(ex is RestException rex)
                {
                    msg = rex.Message;
                    errors = rex.Errors;
                    context.Response.StatusCode = rex.Code;
                }
                await context.Response.WriteAsJsonAsync(new { msg, errors });
            }
        }

    }
}
