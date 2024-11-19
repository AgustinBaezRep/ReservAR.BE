using ReservAR.Application.Login.Commands;
using ReservAR.Application.User.Commands.Create;
using ReservAR.Contracts.Login;

namespace ReservAR.Application.Mappings;

public static class LoginProfiles
{
    public static LoginRequest ToLoginRequest(this LoginCommand command)
    {
        return new LoginRequest(email: command.email, password: command.password);
    }

    public static LoginCommand ToLoginCommand(this LoginRequest request)
    {
        return new LoginCommand(email: request.email, password: request.password);
    }

    public static LoginCommand ToLoginCommand(this CreateUserCommand request)
    {
        return new LoginCommand(email: request.email, password: request.password);
    }
}
