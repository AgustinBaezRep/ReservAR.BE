using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ConsumoAggregate.ValueObjects;
using ReservAR.Domain.ProductoConsumoAggregate;
using ReservAR.Domain.ReservaAggregate;
using ReservAR.Domain.ReservaAggregate.ValueObjects;

namespace ReservAR.Domain.ConsumoAggregate;

public sealed class Consumo : AggregateRoot<ConsumoId>
{
    public string Concepto { get; private set; } = string.Empty;
    public DateTime FechaHora { get; private set; } = DateTime.UtcNow;
    public int? Cantidad { get; private set; }
    public ReservaId? IdReserva { get; private set; }
    public Reserva? Reserva { get; }
    public ComplejoId IdComplejo { get; private set; }
    public Complejo Complejo { get; }

    public ICollection<ProductoConsumo>? ProductosConsumo { get; }

    public Consumo() : base() { }
}
