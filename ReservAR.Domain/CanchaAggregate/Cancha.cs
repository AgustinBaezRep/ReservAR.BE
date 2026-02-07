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

public class Cancha : AggregateRoot<CanchaId>
{
    public string Nombre { get; private set; } = string.Empty;
    public bool Activa { get; private set; }
    public double? Seña { get; private set; }
    public DeporteId IdDeporte { get; private set; }
    public Deporte Deporte { get; }
    public ComplejoId IdComplejo { get; private set; }
    public Complejo Complejo { get; }
    public PisoId IdTipoPiso { get; private set; }
    public Piso TipoPiso { get; }

    public ICollection<Reserva>? Reservas { get; }
    public ICollection<Atributo>? Atributos { get; }
    public ICollection<Precio>? Precios { get; }

    public Cancha() : base() { }

    public virtual void Create(
        string nombre,
        bool activa,
        double? seña,
        DeporteId idDeporte,
        ComplejoId idComplejo,
        PisoId idTipoPiso)
    {
        Id = CanchaId.CreateUnique();
        Nombre = nombre;
        Activa = activa;
        Seña = seña;
        IdDeporte = idDeporte;
        IdComplejo = idComplejo;
        IdTipoPiso = idTipoPiso;
    }
}
