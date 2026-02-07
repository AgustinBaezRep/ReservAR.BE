using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ServicioAggregate.ValueObjects;

namespace ReservAR.Domain.ServicioAggregate;

public sealed class Servicio : AggregateRoot<ServicioId>
{
    public string Descripcion { get; private set; }
    public bool Activo { get; private set; }
    public ComplejoId? IdComplejo { get; private set; }
    public Complejo? Complejo { get; }

    public Servicio() : base() { }
}
