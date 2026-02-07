using ReservAR.Domain.AtributoAggregate.ValueObjects;
using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;

namespace ReservAR.Domain.AtributoAggregate;

public sealed class Atributo : AggregateRoot<AtributoId>
{
    public string Nombre { get; private set; } = string.Empty;
    public bool Activo { get; private set; }
    public CanchaId IdCancha { get; private set; }
    public Cancha Cancha { get; }

    public Atributo() : base() { }
}
