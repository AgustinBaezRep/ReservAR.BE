using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.RolAggregate.ValueObjects;

public class RolId : AggregateRootId
{
    public RolId(Guid value) : base(value)
    {
    }

    public static RolId CreateUnique()
    {
        return new RolId(Guid.NewGuid());
    }

    public static RolId Create(Guid userId)
    {
        return new RolId(userId);
    }
}
