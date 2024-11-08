using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ReservAR.Infraestructure
{
    public static class DependencyInjection
    {
        private const string CONNECTION_STRING = "Server=DESKTOP-O5UPP07;Database=ReservarDb;Trusted_Connection=True;TrustServerCertificate=True;";
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services
                .AddPersistance()
                .AddRepositories();

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            const string connectionString = CONNECTION_STRING;

            services.AddDbContext<ReservarDbContext>(
                options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            // repositories

            return services;
        }
    }
}
