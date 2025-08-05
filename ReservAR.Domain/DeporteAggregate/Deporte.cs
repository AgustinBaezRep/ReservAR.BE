using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.DeporteAggregate.ValueObjects;

namespace ReservAR.Domain.DeporteAggregate;

public class Deporte : AggregateRoot<DeporteId>
{
    public string Nombre { get; set; } = string.Empty;

    public ICollection<Cancha>? Canchas { get; }

    public Deporte() : base() { }
}
