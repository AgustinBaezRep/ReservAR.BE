using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ConsumoAggregate;
using ReservAR.Domain.ConsumoAggregate.ValueObjects;
using ReservAR.Domain.ProductoAggregate;
using ReservAR.Domain.ProductoAggregate.ValueObjects;
using ReservAR.Domain.ProductoConsumoAggregate.ValueObjects;

namespace ReservAR.Domain.ProductoConsumoAggregate;

public sealed class ProductoConsumo : AggregateRoot<ProductoConsumoId>
{
    public ConsumoId IdConsumo { get; private set; }
    public Consumo Consumo { get; }
    public ProductoId IdProducto { get; private set; }
    public Producto Producto { get; }

    public ProductoConsumo() : base() { }
}
