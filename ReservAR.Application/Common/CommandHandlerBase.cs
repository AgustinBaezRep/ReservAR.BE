using ReservAR.Application.Common.Interfaces;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.Common.Models.Identities;

namespace ReservAR.Application.Common
{
    public abstract class CommandHandlerBase<TEntity, TId>(IAggregateLoader aggregateLoader)
    where TEntity : AggregateRoot<TId>
    where TId : AggregateRootId
    {
        protected TEntity? Aggregate { get; set; } = aggregateLoader.CreateAggregate<TEntity, TId>();
    }
}