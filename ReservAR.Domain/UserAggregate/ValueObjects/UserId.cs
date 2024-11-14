using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.UserAggregate.ValueObjects;

public class UserId : AggregateRootId
{
    private UserId(Guid value) : base(value) { }

    public static UserId CreateUnique()
    {
        return new UserId(Guid.NewGuid());
    }

    public static UserId Create(Guid userId)
    {
        return new UserId(userId);
    }
}
