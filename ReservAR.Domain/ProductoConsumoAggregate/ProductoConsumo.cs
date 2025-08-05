using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ConsumoConfiguration;
using ReservAR.Domain.ConsumoConfiguration.ValueObjects;
using ReservAR.Domain.ProductoAggregate;
using ReservAR.Domain.ProductoAggregate.ValueObjects;
using ReservAR.Domain.ProductoConsumoAggregate.ValueObjects;

namespace ReservAR.Domain.ProductoConsumoAggregate;

public sealed class ProductoConsumo : AggregateRoot<ProductoConsumoId>
{
    public ConsumoId IdConsumo { get; set; }
    public Consumo Consumo { get; set; } = new();
    public ProductoId IdProducto { get; set; }
    public Producto Producto { get; set; } = new();

    public ProductoConsumo() : base() { }
}
