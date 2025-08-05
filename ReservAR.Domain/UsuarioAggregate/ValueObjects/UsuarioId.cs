using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.UserAggregate.ValueObjects;

public class UsuarioId : AggregateRootId
{
    private UsuarioId(Guid value) : base(value) { }

    public static UsuarioId CreateUnique()
    {
        return new UsuarioId(Guid.NewGuid());
    }

    public static UsuarioId Create(Guid userId)
    {
        return new UsuarioId(userId);
    }
}
