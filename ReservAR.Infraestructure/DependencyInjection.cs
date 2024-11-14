using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using ReservAR.Application.Common.Interfaces.IRepositories;
using ReservAR.Application.Common.Interfaces.IThirdPartyServices.Authentication;
using ReservAR.Authentication.Services;
using ReservAR.Infraestructure.BackgroundJobs;
using ReservAR.Infraestructure.Persistance;
using ReservAR.Infraestructure.Persistance.Interceptors;
using ReservAR.Infraestructure.Persistance.Repositories;
using ReservAR.Infraestructure.ThirdPartyServices.Authentication;

namespace ReservAR.Infraestructure
{
    public static class DependencyInjection
    {
        private const string CONNECTION_STRING = "Server=DESKTOP-O5UPP07;Database=ReservarDb;Trusted_Connection=True;TrustServerCertificate=True;";
        public static IServiceCollection AddInfraestructure(this IServiceCollection services)
        {
            services
                .AddPersistance()
                .AddRepositories()
                .AddThirdPartyServices()
                .AddAuthenticationGeneratorService()
                .AddQuartzServices();

            return services;
        }

        public static IServiceCollection AddPersistance(this IServiceCollection services)
        {
            const string connectionString = CONNECTION_STRING;

            services.AddDbContext<ReservarDbContext>(
                options => options.UseSqlServer(connectionString));

            services.AddScoped<ConvertDomainEventsToOutboxMessagesInterceptor>();
            services.AddScoped<SaveAuditableDataInterceptor>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }

        public static IServiceCollection AddThirdPartyServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            return services;
        }

        public static IServiceCollection AddAuthenticationGeneratorService(this IServiceCollection services)
        {
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();

            return services;
        }

        private static IServiceCollection AddQuartzServices(this IServiceCollection services)
        {
            services.AddQuartz(configure =>
            {
                var jobKey = new JobKey(nameof(ProcessOutboxMessagesJob));

                configure
                    .AddJob<ProcessOutboxMessagesJob>(jobKey)
                    .AddTrigger(
                        trigger =>
                            trigger.ForJob(jobKey)
                                .WithSimpleSchedule(
                                    schedule =>
                                        schedule.WithIntervalInSeconds(10)
                                            .RepeatForever()));

                configure.UseMicrosoftDependencyInjectionJobFactory();
            });

            services.AddQuartzHostedService();

            return services;
        }
    }
}
