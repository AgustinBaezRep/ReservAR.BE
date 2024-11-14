using ReservAR.Domain.Common.Models;

namespace ReservAR.Domain.UserAggregate.Events;

public record UserCreated(User user) : IDomainEvent;
