using MediatR;
using ReservAR.Application.User.Commands.Create;
using ReservAR.Infraestructure.Persistance;

namespace ReservAR.Presentation.Common.Seeds;

public static class UsersSeeding
{
    public static void Seed(ReservarDbContext context, ISender mediator)
    {
        if (!context.Usuarios.Any())
        {
            List<CreateUserCommand> usersCommands = [];

            usersCommands.Add(new CreateUserCommand("Agustin Ramiro", "Baez", "agustinBaez155@gmail.com", "abc123"));

            foreach(var user in usersCommands)
            {
                mediator.Send(user).GetAwaiter().GetResult();
            }
        }
    }
}
