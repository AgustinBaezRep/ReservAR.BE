using ReservAR.Infraestructure.Persistance;
using ReservAR.Presentation.Common.Seeds;

namespace ReservAR.Presentation;

public static class ReservARInitializer
{
    public static WebApplication Seed(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ReservarDbContext>();

		try
		{
			context.Database.EnsureCreated();

			RolesSeeding.Seed(context);
			DeportesSeeding.Seed(context);
			PisosSeeding.Seed(context);
			AtributosSeeding.Seed(context);
			ServiciosSeeding.Seed(context);

			ComplejosSeeding.Seed(context);

			UsersSeeding.Seed(context);
		}
		catch (Exception)
		{
			throw;
		}

		return application;
    }
}
