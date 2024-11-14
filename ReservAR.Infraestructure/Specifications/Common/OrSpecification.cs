using System.Linq.Expressions;

namespace ReservAR.Infraestructure.Specifications.Common;

internal sealed class OrSpecification<TEntity, TId>(Specification<TEntity, TId> left, Specification<TEntity, TId> right) : Specification<TEntity, TId>
{
    private readonly Specification<TEntity, TId> _left = left;
    private readonly Specification<TEntity, TId> _right = right;

    public override Expression<Func<TEntity, bool>> ToExpression()
    {
        Expression<Func<TEntity, bool>> leftExpression = _left.ToExpression();
        Expression<Func<TEntity, bool>> rightExpression = _right.ToExpression();

        ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity));
        BinaryExpression orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
        orExpression = (BinaryExpression)new ParameterReplacer(parameterExpression).Visit(orExpression);

        return Expression.Lambda<Func<TEntity, bool>>(orExpression, parameterExpression);
    }
}
