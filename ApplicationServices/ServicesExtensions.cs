using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;
using ApplicationServices.Behavior;
using Ardalis.Specification;

namespace ApplicationServices
{
    public static class ServicesExtensions
    {
        public static void AddAplicationLayer(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior <,>), typeof(ValidationBehavior<,>));
            
            
        }
    }
}
