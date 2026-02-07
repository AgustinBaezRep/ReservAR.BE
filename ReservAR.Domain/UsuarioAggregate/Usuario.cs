using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ReservaAggregate;
using ReservAR.Domain.RolAggregate;
using ReservAR.Domain.RolAggregate.ValueObjects;
using ReservAR.Domain.UserAggregate.Events;
using ReservAR.Domain.UserAggregate.ValueObjects;
using System.Numerics;

namespace ReservAR.Domain.UserAggregate;

public class Usuario : AggregateRoot<UsuarioId>
{
    public string Nombre { get; private set; }
    public string Apellido { get; private set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
    public long Telefono { get; private set; }
    public RolId IdRol { get; private set; }
    public Rol Rol { get; }
    public ComplejoId IdComplejo { get; private set; }
    public Complejo Complejo { get; }

    public ICollection<Reserva>? Reservas { get; }

    public Usuario() : base() { }

    public virtual void Create(string firstName,
        string lastName,
        string email,
        string password)
    {
        Id = UsuarioId.CreateUnique();
        Nombre = firstName;
        Apellido = lastName;
        Email = email;
        Password = password;

        AddDomainEvent(new UsuarioCreated(this));
    }
}
