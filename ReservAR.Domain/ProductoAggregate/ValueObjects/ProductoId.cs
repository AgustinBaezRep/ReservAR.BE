using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.ProductoAggregate.ValueObjects;

public class ProductoId : AggregateRootId
{
    public ProductoId(Guid value) : base(value)
    {
    }

    public static ProductoId CreateUnique()
    {
        return new ProductoId(Guid.NewGuid());
    }

    public static ProductoId Create(Guid userId)
    {
        return new ProductoId(userId);
    }
}
