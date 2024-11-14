using ReservAR.Application.Common.Interfaces;
using System.Linq.Expressions;

namespace ReservAR.Infraestructure.Specifications.Common;

internal abstract class Specification<TEntity, TId> : ISpecification<TEntity, TId>
{
    public static readonly Specification<TEntity, TId> All = new IdentitySpecification<TEntity, TId>();

    public List<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];

    public Expression<Func<TEntity, object>>? OrderByExpression { get; private set; }

    public Expression<Func<TEntity, object>>? OrderByDescendingExpression { get; private set; }

    public bool IsSatisfiedBy(TEntity entity)
    {
        Func<TEntity, bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }

    public abstract Expression<Func<TEntity, bool>> ToExpression();

    public Specification<TEntity, TId> And(Specification<TEntity, TId> specification)
    {
        if (this == All)
            return specification;
        if (specification == All)
            return this;

        return new AndSpecification<TEntity, TId>(this, specification);
    }

    public Specification<TEntity, TId> Or(Specification<TEntity, TId> specification)
    {
        if (this == All || specification == All)
            return All;

        return new OrSpecification<TEntity, TId>(this, specification);
    }

    public Specification<TEntity, TId> Not()
    {
        return new NotSpecification<TEntity, TId>(this);
    }

    protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
        IncludeExpressions.Add(includeExpression);

    protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) =>
        OrderByExpression = orderByExpression;

    protected void AddOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression) =>
        OrderByDescendingExpression = orderByDescendingExpression;
}
