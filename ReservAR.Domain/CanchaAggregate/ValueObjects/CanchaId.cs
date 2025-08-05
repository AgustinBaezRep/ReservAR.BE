using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.CanchaAggregate.ValueObjects;

public class CanchaId : AggregateRootId
{
    public CanchaId(Guid value) : base(value)
    {
    }

    public static CanchaId CreateUnique()
    {
        return new CanchaId(Guid.NewGuid());
    }

    public static CanchaId Create(Guid userId)
    {
        return new CanchaId(userId);
    }
}
