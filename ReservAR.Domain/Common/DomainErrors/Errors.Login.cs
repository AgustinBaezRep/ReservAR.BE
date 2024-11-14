using ErrorOr;

namespace ReservAR.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error IncorrectCredentials()
        {
            return Error.NotFound(code: "User.NotFound",
                description: "The credentials you introduced are wrong.");
        }
    }
}
