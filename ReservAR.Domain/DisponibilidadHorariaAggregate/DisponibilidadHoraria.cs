using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.DisponibilidadHorariaAggregate.ValueObjects;

namespace ReservAR.Domain.DisponibilidadHorariaAggregate;

public sealed class DisponibilidadHoraria : AggregateRoot<DisponibilidadHorariaId>
{
    public string Dia { get; private set; } = string.Empty;
    public int HoraDesde { get; private set; }
    public int HoraHasta { get; private set; }
    public bool Activo { get; private set; }
    public ComplejoId IdComplejo { get; private set; }
    public Complejo Complejo { get; }

    public DisponibilidadHoraria() : base() { }
}
