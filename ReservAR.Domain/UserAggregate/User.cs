using ReservAR.Domain.Common.Models;
using ReservAR.Domain.UserAggregate.Events;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Domain.UserAggregate;

public class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; } = "Agustin";
    public string LastName { get; private set; } = "Baez";
    public string Email { get; private set; } = "Agustin@hotmail.com";
    public string Password { get; private set; } = "Agustin123";


    public User() : base() { }

    public virtual void Create(string firstName,
        string lastName,
        string email,
        string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;

        AddDomainEvent(new UserCreated(this));
    }
}
