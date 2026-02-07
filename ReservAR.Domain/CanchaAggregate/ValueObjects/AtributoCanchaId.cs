using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.CanchaAggregate.ValueObjects;

public sealed class AtributoCanchaId : AggregateRootId
{
    public AtributoCanchaId(Guid value) : base(value)
    {
    }

    public static AtributoCanchaId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static AtributoCanchaId Create(Guid value)
    {
        return new AtributoCanchaId(value);
    }
}
