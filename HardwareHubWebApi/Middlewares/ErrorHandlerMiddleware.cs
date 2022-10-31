using ApplicationServices.Exeptions;
using ApplicationServices.Wrappers;
using System.Text.Json;

namespace HardwareHubWebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception Error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>();

                responseModel = new Response<string>() { Succeed = false, Message = Error?.Message };



                switch (Error)
                {
                    case ApiException e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        break;
                    case ValidationExeptions e:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        break;
                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);

                await response.WriteAsync(result);

            }
        }
    }
}
