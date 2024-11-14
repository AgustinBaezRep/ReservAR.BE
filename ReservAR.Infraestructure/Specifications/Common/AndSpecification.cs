using System.Linq.Expressions;

namespace ReservAR.Infraestructure.Specifications.Common;

internal sealed class AndSpecification<TEntity, TId>(Specification<TEntity, TId> left, Specification<TEntity, TId> right) : Specification<TEntity, TId>
{
    private readonly Specification<TEntity, TId> _left = left;
    private readonly Specification<TEntity, TId> _right = right;

    public override Expression<Func<TEntity, bool>> ToExpression()
    {
        Expression<Func<TEntity, bool>> leftExpression = _left.ToExpression();
        Expression<Func<TEntity, bool>> rightExpression = _right.ToExpression();

        ParameterExpression parameterExpression = Expression.Parameter(typeof(TEntity));
        BinaryExpression andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
        andExpression = (BinaryExpression)new ParameterReplacer(parameterExpression).Visit(andExpression);

        return Expression.Lambda<Func<TEntity, bool>>(andExpression, parameterExpression);
    }
}
