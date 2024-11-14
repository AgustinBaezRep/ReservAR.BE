namespace ReservAR.Application.Common.Interfaces;

public interface ISpecification<TEntity, TId>
{
    bool IsSatisfiedBy(TEntity entity);
}
