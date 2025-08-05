using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ReservaAggregate.ValueObjects;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Domain.ReservaAggregate;

public sealed class Reserva : AggregateRoot<ReservaId>
{
    public bool Fijo { get; set; }
    public DateOnly Dia { get; set; }
    public int Hora { get; set; }
    public TipoPago Pago { get; set; }
    public CanchaId IdCancha { get; set; }
    public Cancha Cancha { get; set; } = new();
    public UsuarioId IdUsuario { get; set; }
    public Usuario Usuario { get; set; } = new();

    public Reserva() : base() { }
}

public enum TipoPago
{
    MercadoPago,
    Efectivo
}
