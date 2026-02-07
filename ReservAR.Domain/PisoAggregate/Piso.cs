using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.PisoAggregate.Enums;
using ReservAR.Domain.PisoAggregate.ValueObjects;

namespace ReservAR.Domain.PisoAggregate;

public sealed class Piso : AggregateRoot<PisoId>
{
    public TipoPiso Descripcion { get; private set; }

    public ICollection<Cancha>? Canchas { get; }

    public Piso() : base() { }
}


