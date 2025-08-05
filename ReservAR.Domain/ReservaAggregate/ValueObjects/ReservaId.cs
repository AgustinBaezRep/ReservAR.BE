using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.ReservaAggregate.ValueObjects;

public class ReservaId : AggregateRootId
{
    public ReservaId(Guid value) : base(value)
    {
    }

    public static ReservaId CreateUnique()
    {
        return new ReservaId(Guid.NewGuid());
    }

    public static ReservaId Create(Guid userId)
    {
        return new ReservaId(userId);
    }
}
