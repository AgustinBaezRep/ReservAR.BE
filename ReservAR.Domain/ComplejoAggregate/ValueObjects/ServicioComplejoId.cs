using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.ComplejoAggregate.ValueObjects;

public sealed class ServicioComplejoId : AggregateRootId
{
    public ServicioComplejoId(Guid value) : base(value)
    {
    }

    public static ServicioComplejoId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static ServicioComplejoId Create(Guid value)
    {
        return new ServicioComplejoId(value);
    }
}
