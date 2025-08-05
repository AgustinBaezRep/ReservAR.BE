using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ServicioAggregate.ValueObjects;

namespace ReservAR.Domain.ServicioAggregate;

public sealed class Servicio : AggregateRoot<ServicioId>
{
    public string Descripcion { get; set; } = string.Empty;
    public bool Activo { get; set; }
    public ComplejoId? IdComplejo { get; set; }
    public Complejo? Complejo { get; } = new();

    public Servicio() : base() { }
}
