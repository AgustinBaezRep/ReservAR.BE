using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.ComplejoAggregate.ValueObjects;

public class ComplejoId : AggregateRootId
{
    public ComplejoId(Guid value) : base(value)
    {
    }

    public static ComplejoId CreateUnique()
    {
        return new ComplejoId(Guid.NewGuid());
    }

    public static ComplejoId Create(Guid userId)
    {
        return new ComplejoId(userId);
    }
}
