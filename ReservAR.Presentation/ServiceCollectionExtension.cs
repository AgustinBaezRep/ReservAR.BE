using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.OpenApi.Models;
using ReservAR.Application.Helpers.Errors;
using ReservAR.Presentation.Common.OptionsSetup;
using Swashbuckle.AspNetCore.Filters;

namespace ReservAR.Presentation
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            services.AddReservARConsultingProblemDetails()
                .AddEndpointsApiExplorer()
                .AddOptionsConfiguration()
                .AddSwagger()
                .AddAuthentication();

            return services;
        }

        private static IServiceCollection AddOptionsConfiguration(this IServiceCollection services)
        {
            services.ConfigureOptions<JwtOptionsSetup>();
            services.ConfigureOptions<JwtBearerOptionsSetup>();

            return services;
        }

        private static IServiceCollection AddReservARConsultingProblemDetails(this IServiceCollection services)
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

        public static IServiceCollection AddAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer();

            return services;
        }
    }
}