using ReservAR.Domain.Common.Models;
using ReservAR.Domain.RolAggregate.ValueObjects;

namespace ReservAR.Domain.RolAggregate;

public sealed class Rol : AggregateRoot<RolId>
{
    public string Descripcion { get; private set; }

    public Rol() : base() { }
}
