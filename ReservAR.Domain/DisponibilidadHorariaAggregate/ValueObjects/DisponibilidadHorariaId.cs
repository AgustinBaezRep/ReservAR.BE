using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Domain.DisponibilidadHorariaAggregate.ValueObjects;

public class DisponibilidadHorariaId : AggregateRootId
{
    public DisponibilidadHorariaId(Guid value) : base(value)
    {
    }

    public static DisponibilidadHorariaId CreateUnique()
    {
        return new DisponibilidadHorariaId(Guid.NewGuid());
    }

    public static DisponibilidadHorariaId Create(Guid userId)
    {
        return new DisponibilidadHorariaId(userId);
    }
}
