using ReservAR.Domain.Common.Models;

using ReservAR.Domain.ServicioAggregate.ValueObjects;

namespace ReservAR.Domain.ServicioAggregate;

public sealed class Servicio : AggregateRoot<ServicioId>
{
    public string Descripcion { get; private set; }
    public bool Activo { get; private set; }


    public Servicio() : base() { }
}
