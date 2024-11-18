using ReservAR.Application.User.Commands.Create;
using ReservAR.Contracts.User;

namespace ReservAR.Application.Mappings
{
    public static class UserProfiles
    {
        public static CreateUserCommand ToCreateUserCommand(this CreateUserRequest command)
        {
            return new CreateUserCommand(firstName: command.firstName,
                lastName: command.lastName,
                email: command.email,
                password: command.password);
        }
    }
}
