using MediatR;
using ReservAR.Infraestructure.Persistance;
using ReservAR.Presentation.Common.Seeds;

namespace ReservAR.Presentation;

public static class ReservARInitializer
{
    public static WebApplication Seed(this WebApplication application)
    {
        using var scope = application.Services.CreateScope();
        using var context = scope.ServiceProvider.GetRequiredService<ReservarDbContext>();
        var mediator = scope.ServiceProvider.GetRequiredService<ISender>();

		try
		{
			context.Database.EnsureCreated();

			UsersSeeding.Seed(context, mediator);
		}
		catch (Exception)
		{
			throw;
		}

		return application;
    }
}
