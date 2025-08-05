using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.AtributoAggregate.ValueObjects;

public class AtributoId : AggregateRootId
{
    public AtributoId(Guid value) : base(value)
    {
    }

    public static AtributoId CreateUnique()
    {
        return new AtributoId(Guid.NewGuid());
    }

    public static AtributoId Create(Guid atributo)
    {
        return new AtributoId(atributo);
    }
}
