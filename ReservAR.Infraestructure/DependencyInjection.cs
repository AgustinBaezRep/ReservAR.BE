using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Infraestructure.Persistance.Repositories;

namespace ReservAR.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services.AddPersistance();

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            const string connectionString = "Server=DESKTOP-O5UPP07;Database=ReservarDb;Trusted_Connection=True;TrustServerCertificate=True;";
            services.AddDbContext<ReservarDbContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IBookingRepository, BookingRepository>();

            return services;
        }
    }
}
