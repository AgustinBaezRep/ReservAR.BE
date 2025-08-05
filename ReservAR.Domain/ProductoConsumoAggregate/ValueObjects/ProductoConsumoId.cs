using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.ProductoConsumoAggregate.ValueObjects;

public class ProductoConsumoId : AggregateRootId
{
    public ProductoConsumoId(Guid value) : base(value)
    {
    }

    public static ProductoConsumoId CreateUnique()
    {
        return new ProductoConsumoId(Guid.NewGuid());
    }

    public static ProductoConsumoId Create(Guid userId)
    {
        return new ProductoConsumoId(userId);
    }
}
