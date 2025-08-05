using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.PisoAggregate.ValueObjects;

public class PisoId : AggregateRootId
{
    public PisoId(Guid value) : base(value)
    {
    }

    public static PisoId CreateUnique()
    {
        return new PisoId(Guid.NewGuid());
    }

    public static PisoId Create(Guid userId)
    {
        return new PisoId(userId);
    }
}
