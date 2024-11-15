using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ReservAR.Application.Common.Behaviors;
using ReservAR.Application.Common.Interfaces;
using ReservAR.Application.Common;
using System.Reflection;

namespace ReservAR.Application
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtension).Assembly));

            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<IAggregateLoader, AggregateLoader>();

            return services;
        }
    }
}