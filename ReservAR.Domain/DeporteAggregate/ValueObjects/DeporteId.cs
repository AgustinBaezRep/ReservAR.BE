using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.DeporteAggregate.ValueObjects;

public class DeporteId : AggregateRootId
{
    public DeporteId(Guid value) : base(value)
    {
    }

    public static DeporteId CreateUnique()
    {
        return new DeporteId(Guid.NewGuid());
    }

    public static DeporteId Create(Guid userId)
    {
        return new DeporteId(userId);
    }
}
