using ReservAR.Domain.Common.Models;
using ReservAR.Domain.DireccionAggregate.ValueObjects;

namespace ReservAR.Domain.DireccionAggregate;

public sealed class Direccion : AggregateRoot<DireccionId>
{
    public string Descripcion { get; private set; } = string.Empty;
    public string? CoordenadaX { get; private set; }
    public string? CoordenadaY { get; private set; }

    public Direccion() : base() { }
}
