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

            return services;
        }
    }
}