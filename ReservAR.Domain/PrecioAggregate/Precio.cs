using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.PrecioAggregate.Enums;
using ReservAR.Domain.PrecioAggregate.ValueObjects;

namespace ReservAR.Domain.PrecioAggregate;

public sealed class Precio : AggregateRoot<PrecioId>
{
    public TiposPrecio TipoPrecio { get; private set; }
    public decimal Valor { get; private set; }
    public int? TopeHorario { get; private set; }
    public CanchaId IdCancha { get; private set; }
    public Cancha Cancha { get; }

    public Precio() : base() { }
}