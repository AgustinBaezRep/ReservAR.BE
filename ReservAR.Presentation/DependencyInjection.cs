using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using ReservAR.Application.Helpers.Errors;
using Swashbuckle.AspNetCore.Filters;

namespace ReservAR.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddDataDrivenConsultingProblemDetails();
            services.AddSwagger();
            services.AddAuthentication();

            return services;
        }

        private static IServiceCollection AddDataDrivenConsultingProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails();
            services.AddExceptionHandler<CustomExceptionHandler>();

            services.AddSingleton<ProblemDetailsFactory, ReservarProblemFactory>();

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            return services;
        }


        public static IServiceCollection AddAuthentication(this IServiceCollection services, WebApplicationBuilder configuration)
        {

            return services;
        }
    }
}