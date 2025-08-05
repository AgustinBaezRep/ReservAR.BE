using ReservAR.Domain.AtributoAggregate;
using ReservAR.Domain.CanchaAggregate.ValueObjects;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.DeporteAggregate;
using ReservAR.Domain.DeporteAggregate.ValueObjects;
using ReservAR.Domain.PisoAggregate;
using ReservAR.Domain.PisoAggregate.ValueObjects;
using ReservAR.Domain.PrecioAggregate;
using ReservAR.Domain.ReservaAggregate;

namespace ReservAR.Domain.CanchaAggregate;

public sealed class Cancha : AggregateRoot<CanchaId>
{
    public string Nombre { get; set; } = string.Empty;
    public bool Activa { get; set; }
    public double? Seña { get; set; }
    public DeporteId IdDeporte { get; set; }
    public Deporte Deporte { get; set; } = new();
    public ComplejoId IdComplejo { get; set; }
    public Complejo Complejo { get; set; } = new();
    public PisoId IdTipoPiso { get; set; }
    public Piso TipoPiso { get; set; } = new();

    public ICollection<Reserva>? Reservas { get; }
    public ICollection<Atributo>? Atributos { get; }
    public ICollection<Precio>? Precios { get; }

    public Cancha() : base() { }
}
