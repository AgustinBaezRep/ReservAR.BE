namespace ReservAR.Domain.Common.Models.Identities
{
    public abstract class AggregateRootId : EntityId
    {
        protected AggregateRootId(Guid value) : base(value) { }
    }
}
