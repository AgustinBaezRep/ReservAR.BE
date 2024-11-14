namespace ReservAR.Domain.Common.Models;

public abstract class EntityBase<TId> : IEquatable<EntityBase<TId>>
where TId : ValueObject
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public TId Id { get; protected set; }

    protected EntityBase()
    {
    }

    public override bool Equals(object? obj)
    {
        return obj is EntityBase<TId> entity && Id.Equals(entity.Id);
    }

    public bool Equals(EntityBase<TId>? other)
    {
        return Equals((object?)other);
    }

    public static bool operator ==(EntityBase<TId> left, EntityBase<TId> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(EntityBase<TId> left, EntityBase<TId> right)
    {
        return !Equals(left, right);
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}