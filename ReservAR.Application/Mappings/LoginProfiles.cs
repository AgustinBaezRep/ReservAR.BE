using ReservAR.Application.Login.Commands;
using ReservAR.Contracts.Login;

namespace ReservAR.Application.Mappings
{
    public static class LoginProfiles
    {
        public static LoginRequest ToLoginRequest(this LoginCommand command)
        {
            return new LoginRequest(email: command.email, password: command.password);
        }

        public static LoginCommand ToLoginCommand(this LoginRequest command)
        {
            return new LoginCommand(email: command.email, password: command.password);
        }
    }
}
