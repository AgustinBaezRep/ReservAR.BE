using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ConsumoConfiguration.ValueObjects;
using ReservAR.Domain.ProductoConsumoAggregate;
using ReservAR.Domain.ReservaAggregate;
using ReservAR.Domain.ReservaAggregate.ValueObjects;

namespace ReservAR.Domain.ConsumoConfiguration;

public sealed class Consumo : AggregateRoot<ConsumoId>
{
    public string Concepto { get; set; } = string.Empty;
    public DateTime FechaHora { get; set; } = DateTime.UtcNow;
    public int? Cantidad { get; set; }
    public ReservaId? IdReserva { get; set; }
    public Reserva? Reserva { get; }
    public ComplejoId IdComplejo { get; set; }
    public Complejo Complejo { get; } = new();

    public ICollection<ProductoConsumo>? ProductosConsumo { get; }

    public Consumo() : base() { }
}
