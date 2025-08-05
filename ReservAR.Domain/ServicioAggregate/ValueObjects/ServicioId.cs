using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.ServicioAggregate.ValueObjects;

public class ServicioId : AggregateRootId
{
    public ServicioId(Guid value) : base(value)
    {
    }

    public static ServicioId CreateUnique()
    {
        return new ServicioId(Guid.NewGuid());
    }

    public static ServicioId Create(Guid userId)
    {
        return new ServicioId(userId);
    }
}
