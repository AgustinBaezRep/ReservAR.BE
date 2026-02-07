using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ComplejoAggregate.ValueObjects;
using ReservAR.Domain.ProductoAggregate.ValueObjects;
using ReservAR.Domain.ProductoConsumoAggregate;

namespace ReservAR.Domain.ProductoAggregate;

public sealed class Producto : AggregateRoot<ProductoId>
{
    public string Descripcion { get; private set; } = string.Empty;
    public double? PrecioCompra { get; private set; }
    public double PrecioVenta { get; private set; }
    public int Stock { get; private set; }
    public ComplejoId IdComplejo { get; private set; }
    public Complejo Complejo { get; }

    public ICollection<ProductoConsumo>? ProductosConsumo { get; }

    public Producto() : base() { }
}
