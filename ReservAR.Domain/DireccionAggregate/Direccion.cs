using ReservAR.Domain.Common.Models;
using ReservAR.Domain.DireccionAggregate.ValueObjects;

namespace ReservAR.Domain.DireccionAggregate;

public sealed class Direccion : AggregateRoot<DireccionId>
{
    public string Descripcion { get; set; } = string.Empty;
    public string? CoordenadaX { get; set; }
    public string? CoordenadaY { get; set; }

    public Direccion() : base() { }
}
