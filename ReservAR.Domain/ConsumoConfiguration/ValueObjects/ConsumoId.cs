using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.ConsumoConfiguration.ValueObjects;

public class ConsumoId : AggregateRootId
{
    public ConsumoId(Guid value) : base(value)
    {
    }

    public static ConsumoId CreateUnique()
    {
        return new ConsumoId(Guid.NewGuid());
    }

    public static ConsumoId Create(Guid userId)
    {
        return new ConsumoId(userId);
    }
}
