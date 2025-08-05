using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.PrecioAggregate.ValueObjects;

namespace ReservAR.Domain.PrecioAggregate;

public sealed class Precio : AggregateRoot<PrecioId>
{
    public TiposPrecio TipoPrecio { get; set; }
    public decimal Valor { get; set; }
    public int? TopeHorario { get; set; }
    public CanchaId IdCancha { get; set; }
    public Cancha Cancha { get; }

    public Precio() : base() { }
}

public enum TiposPrecio
{
    Unico,
    Intervalos
}
