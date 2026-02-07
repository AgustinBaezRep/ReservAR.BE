using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ServicioAggregate;
using ReservAR.Domain.ServicioAggregate.ValueObjects;

namespace ReservAR.Domain.ComplejoAggregate;

public sealed class ServicioComplejo : EntityBase<ServicioComplejoId>
{
    public ComplejoId IdComplejo { get; private set; }
    public Complejo Complejo { get; }
    public ServicioId IdServicio { get; private set; }
    public Servicio Servicio { get; }

    public ServicioComplejo() { }

    internal ServicioComplejo(ComplejoId idComplejo, ServicioId idServicio)
    {
        Id = ServicioComplejoId.CreateUnique();
        IdComplejo = idComplejo;
        IdServicio = idServicio;
    }
}
