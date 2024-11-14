using ReservAR.Domain.Common.Models.Identities;
using ReservAR.Domain.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace ReservAR.Infraestructure.Specifications.Common;

internal static class SpecificationEvaluator
{
    public static IQueryable<TEntity> GetQuery<TEntity, TId>(IQueryable<TEntity> inputQueryable, Specification<TEntity, TId> specification)
        where TEntity : EntityBase<TId>
        where TId : AggregateRootId
    {
        IQueryable<TEntity> queryable = inputQueryable;

        queryable = queryable.Where(specification.ToExpression());

        queryable = specification.IncludeExpressions.Aggregate(queryable, (current, includeExpression) => current.Include(includeExpression));

        if (specification.OrderByExpression is not null)
        {
            queryable = queryable.OrderBy(specification.OrderByExpression);
        }
        else if (specification.OrderByDescendingExpression is not null)
        {
            queryable = queryable.OrderByDescending(specification.OrderByDescendingExpression);
        }

        return queryable;
    }
}
