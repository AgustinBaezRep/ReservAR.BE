using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReservAR.Application.IRepositories;
using ReservAR.Domain.User;
using ReservAR.Infraestructure;
using ReservAR.Infraestructure.Persistance.Repositories;

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