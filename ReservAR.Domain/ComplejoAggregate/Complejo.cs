using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ConsumoConfiguration;
using ReservAR.Domain.DireccionAggregate;
using ReservAR.Domain.DireccionAggregate.ValueObjects;
using ReservAR.Domain.DisponibilidadHorariaAggregate;
using ReservAR.Domain.ProductoAggregate;
using ReservAR.Domain.ServicioAggregate;
using ReservAR.Domain.UserAggregate;

namespace ReservAR.Domain.ComplejoAggregate;

public sealed class Complejo : AggregateRoot<ComplejoId>
{
    public string Nombre { get; set; } = string.Empty;
    public long Telefono { get; set; }
    public bool Online { get; set; }
    public DireccionId? IdDireccion { get; set; }
    public Direccion? Direccion { get; }

    public ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
    public ICollection<Producto>? Productos { get; }
    public ICollection<Consumo>? Consumos { get; }
    public ICollection<Cancha>? Canchas { get; }
    public ICollection<Servicio>? Servicios { get; }
    public ICollection<DisponibilidadHoraria>? DisponibilidadesHorarias { get; }

    public Complejo() : base() { }

    public static Complejo Create(string nombre, long telefono, bool online, Guid? idDireccion)
    {
        var newComplejo = new Complejo
        {
            Id = ComplejoId.Create(Guid.NewGuid()),
            Nombre = nombre,
            Telefono = telefono,
            Online = online,
            IdDireccion = idDireccion is not null ? DireccionId.Create(idDireccion.Value) : null
        };

        newComplejo.SetCreatedData(DateTime.UtcNow);

        return newComplejo;
    }

    public static void Update(Complejo complejo, string? nombre, long? telefono, bool? online, Guid? idDireccion)
    {
        complejo.Nombre = nombre is not null ? nombre : complejo.Nombre;
        complejo.Telefono = telefono is not null ? telefono.Value : complejo.Telefono;
        complejo.Online = online is not null ? online.Value : complejo.Online;
        complejo.IdDireccion = idDireccion is not null ? DireccionId.Create(idDireccion.Value) : complejo.IdDireccion;

        complejo.SetUpdatedData(DateTime.UtcNow);
    }

    public static void Delete(Complejo complejo)
    {
        complejo.SetDeletedData(DateTime.UtcNow);
    }

    public static void Activate(Complejo complejo)
    {
        complejo.Online = !complejo.Online;

        complejo.SetUpdatedData(DateTime.UtcNow);
    }
}
