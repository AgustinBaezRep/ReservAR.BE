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
    public string Nombre { get; set; } = string.Empty;
    public string Apellido { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public long Telefono { get; set; }
    public RolId IdRol { get; set; }
    public Rol Rol { get; } = new();
    public ComplejoId IdComplejo { get; set; }
    public Complejo Complejo { get; } = new();

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
