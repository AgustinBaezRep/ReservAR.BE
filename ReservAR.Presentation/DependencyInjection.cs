using Microsoft.AspNetCore.Identity;
using ReservAR.Domain.User;
using ReservAR.Infraestructure;

namespace ReservAR.Presentation
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services, WebApplicationBuilder configuration)
        {
            return services.AddAuthentication(configuration);
        }

        public static IServiceCollection AddAuthentication(this IServiceCollection services, WebApplicationBuilder configuration)
        {
            configuration.Services.AddAuthorization();
            configuration.Services.AddAuthentication().AddCookie(IdentityConstants.ApplicationScheme);
            configuration.Services.AddIdentityCore<User>().AddEntityFrameworkStores<ReservarDbContext>().AddApiEndpoints();

            return services;
        }
    }
}