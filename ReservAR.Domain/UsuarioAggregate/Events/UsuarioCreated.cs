using ReservAR.Domain.Common.Models;

namespace ReservAR.Domain.UserAggregate.Events;

public record UsuarioCreated(Usuario user) : IDomainEvent;
