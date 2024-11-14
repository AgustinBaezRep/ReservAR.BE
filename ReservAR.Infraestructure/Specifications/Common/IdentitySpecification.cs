using System.Linq.Expressions;

namespace ReservAR.Infraestructure.Specifications.Common;

internal sealed class IdentitySpecification<TEntity, TId> : Specification<TEntity, TId>
{
    public override Expression<Func<TEntity, bool>> ToExpression()
    {
        return x => true;
    }
}
