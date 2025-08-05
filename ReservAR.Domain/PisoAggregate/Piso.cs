using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.PisoAggregate.ValueObjects;

namespace ReservAR.Domain.PisoAggregate;

public sealed class Piso : AggregateRoot<PisoId>
{
    public TipoPiso Descripcion { get; set; }

    public ICollection<Cancha>? Canchas { get; }

    public Piso() : base() { }
}

public enum TipoPiso
{
    Cesped = 0,
    Sintetico = 1,
    Ladrillo = 2,
    Caucho = 3
}
