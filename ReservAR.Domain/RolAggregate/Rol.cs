using ReservAR.Domain.Common.Models;
using ReservAR.Domain.RolAggregate.ValueObjects;

namespace ReservAR.Domain.RolAggregate;

public sealed class Rol : AggregateRoot<RolId>
{
    public string Descripcion { get; set; } = string.Empty;

    public Rol() : base() { }
}
