using HardwareHubWebApi.Middlewares;

namespace HardwareHubWebApi.Extensions
{
    public static class AppExtensions
    {
        public static void UseErrorHandlingMiddlerware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
