using ErrorOr;

namespace ReservAR.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error AlreadyExistingUser()
        {
            return Error.Conflict(code: "User.Conflict",
                description: "The email has already been chosen by another user.");
        }
    }
}
