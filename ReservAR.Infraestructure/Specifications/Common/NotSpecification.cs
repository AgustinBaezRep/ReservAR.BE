using System.Linq.Expressions;

namespace ReservAR.Infraestructure.Specifications.Common;

internal sealed class NotSpecification<TEntity, TId>(Specification<TEntity, TId> specification) : Specification<TEntity, TId>
{
    private readonly Specification<TEntity, TId> _specification = specification;

    public override Expression<Func<TEntity, bool>> ToExpression()
    {
        Expression<Func<TEntity, bool>> expression = _specification.ToExpression();

        ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity));
        UnaryExpression notExpression = Expression.Not(expression.Body);
        notExpression = (UnaryExpression)new ParameterReplacer(parameterExpression).Visit(notExpression);

        return Expression.Lambda<Func<TEntity, bool>>(notExpression, parameterExpression);
    }
}
