using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ConsumoAggregate;
using ReservAR.Domain.DireccionAggregate;
using ReservAR.Domain.DireccionAggregate.ValueObjects;
using ReservAR.Domain.DisponibilidadHorariaAggregate;
using ReservAR.Domain.ProductoAggregate;
using ReservAR.Domain.ServicioAggregate;
using ReservAR.Domain.UserAggregate;

namespace ReservAR.Domain.ComplejoAggregate;

public sealed class Complejo : AggregateRoot<ComplejoId>
{
    public string Nombre { get; private set; } = string.Empty;
    public long Telefono { get; private set; }
    public bool Online { get; private set; }
    public DireccionId? IdDireccion { get; private set; }
    public Direccion? Direccion { get; }

    public ICollection<Usuario> Usuarios { get; }
    public ICollection<Producto>? Productos { get; }
    public ICollection<Consumo>? Consumos { get; }
    public ICollection<Cancha>? Canchas { get; }
    public ICollection<ServicioComplejo>? Servicios { get; }
    public ICollection<DisponibilidadHoraria>? DisponibilidadesHorarias { get; }

    public Complejo() : base() { }

    public Complejo Create(string nombre, long telefono, bool online, Guid? idDireccion)
    {
        return new Complejo
        {
            Id = ComplejoId.CreateUnique(),
            Nombre = nombre,
            Telefono = telefono,
            Online = online,
            IdDireccion = idDireccion is not null ? DireccionId.Create(idDireccion.Value) : null
        };
    }
}