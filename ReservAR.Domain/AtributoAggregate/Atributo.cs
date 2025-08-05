using ReservAR.Domain.AtributoAggregate.ValueObjects;
using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;

namespace ReservAR.Domain.AtributoAggregate;

public sealed class Atributo : AggregateRoot<AtributoId>
{
    public string Nombre { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public CanchaId IdCancha { get; set; }
    public Cancha Cancha { get; set; } = new();

    public Atributo() : base() { }
}
