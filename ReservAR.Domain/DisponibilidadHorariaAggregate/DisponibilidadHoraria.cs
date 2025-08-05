using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.DisponibilidadHorariaAggregate.ValueObjects;

namespace ReservAR.Domain.DisponibilidadHorariaAggregate;

public sealed class DisponibilidadHoraria : AggregateRoot<DisponibilidadHorariaId>
{
    public string Dia { get; set; } = string.Empty;
    public int HoraDesde { get; set; }
    public int HoraHasta { get; set; }
    public bool Activo { get; set; }
    public ComplejoId IdComplejo { get; set; }
    public Complejo Complejo { get; } = new();

    public DisponibilidadHoraria() : base() { }
}
