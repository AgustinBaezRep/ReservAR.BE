using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ReservaAggregate.Enums;
using ReservAR.Domain.ReservaAggregate.ValueObjects;
using ReservAR.Domain.UserAggregate;
using ReservAR.Domain.UserAggregate.ValueObjects;

namespace ReservAR.Domain.ReservaAggregate;

public sealed class Reserva : AggregateRoot<ReservaId>
{
    public bool Fijo { get; private set; }
    public DateOnly Dia { get; private set; }
    public int Hora { get; private set; }
    public TipoPago Pago { get; private set; }
    public CanchaId IdCancha { get; private set; }
    public Cancha Cancha { get; }
    public UsuarioId IdUsuario { get; private set; }
    public Usuario Usuario { get; }

    public Reserva() : base() { }
}