using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.RolAggregate.ValueObjects;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class UsersSeeding
{
    public static void Seed(ReservarDbContext context)
    {
        if (!context.Usuarios.Any())
        {
            var usuario = new Usuario();
            usuario.Create(
                "Agustin Ramiro",
                "Baez",
                "agustinBaez155@gmail.com",
                "abc123",
                ComplejosSeeding.DefaultComplejoId,
                RolesSeeding.AdminRolId
            );

            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }
    }
}
