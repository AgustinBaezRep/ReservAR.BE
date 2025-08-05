using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.DireccionAggregate.ValueObjects;

public class DireccionId : AggregateRootId
{
    public DireccionId(Guid value) : base(value)
    {
    }

    public static DireccionId CreateUnique()
    {
        return new DireccionId(Guid.NewGuid());
    }

    public static DireccionId Create(Guid userId)
    {
        return new DireccionId(userId);
    }
}
