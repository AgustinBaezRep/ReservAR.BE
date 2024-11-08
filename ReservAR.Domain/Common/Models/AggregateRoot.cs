namespace ReservAR.Domain.Common.Models;

public abstract class AggregateRoot<TId> : EntityBase<TId>, IAuditableAggregate, IHasDomainEvents
where TId : ValueObject
{
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public DateTime? DeletedDateTime { get; private set; }
    public bool IsDeleted { get; private set; }

    protected AggregateRoot() : base() { }

    public void SetCreatedData(DateTime createdDateTime)
    {
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = createdDateTime;
    }

    public void SetUpdatedData(DateTime updatedDateTime)
    {
        UpdatedDateTime = updatedDateTime;
    }

    public void SetDeletedData(DateTime deletedDateTime)
    {
        DeletedDateTime = deletedDateTime;
        IsDeleted = true;
    }
}