using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ProductoAggregate.ValueObjects;
using ReservAR.Domain.ProductoConsumoAggregate;

namespace ReservAR.Domain.ProductoAggregate;

public sealed class Producto : AggregateRoot<ProductoId>
{
    public string Descripcion { get; set; } = string.Empty;
    public double? PrecioCompra { get; set; }
    public double PrecioVenta { get; set; }
    public int Stock { get; set; }
    public ComplejoId IdComplejo { get; set; }
    public Complejo Complejo { get; } = new();

    public ICollection<ProductoConsumo>? ProductosConsumo { get; }

    public Producto() : base() { }
}
