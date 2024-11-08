using ReservAR.Domain.Common.Models;
using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Application.Common.Interfaces;

public interface IAggregateLoader
{
    TAggregate CreateAggregate<TAggregate, TId>()
        where TAggregate : AggregateRoot<TId>
        where TId : AggregateRootId;
}
