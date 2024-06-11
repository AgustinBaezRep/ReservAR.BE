using Microsoft.AspNetCore.Identity;

namespace ReservAR.Domain.User
{
    public class User : IdentityUser
    {
        public string? Initials { get; set; }
    }
}
