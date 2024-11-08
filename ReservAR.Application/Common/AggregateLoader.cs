using ReservAR.Application.Common.Interfaces;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Application.Common;

public class AggregateLoader : IAggregateLoader
{
    public TAggregate CreateAggregate<TAggregate, TId>()
        where TAggregate : AggregateRoot<TId>
        where TId : AggregateRootId
    {
        return Activator.CreateInstance<TAggregate>();
    }
}