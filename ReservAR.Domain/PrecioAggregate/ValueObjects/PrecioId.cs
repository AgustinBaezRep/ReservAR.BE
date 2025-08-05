using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.PrecioAggregate.ValueObjects;

public class PrecioId : AggregateRootId
{
    public PrecioId(Guid value) : base(value)
    {
    }

    public static PrecioId CreateUnique()
    {
        return new PrecioId(Guid.NewGuid());
    }

    public static PrecioId Create(Guid userId)
    {
        return new PrecioId(userId);
    }
}
