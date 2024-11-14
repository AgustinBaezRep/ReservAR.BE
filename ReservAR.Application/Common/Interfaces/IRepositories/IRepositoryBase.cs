using ReservAR.Domain.Common.Models;
using System.Linq.Expressions;

namespace ReservAR.Application.Common.Interfaces.IRepositories;

public interface IRepositoryBase<TEntity, TId>
    where TEntity : EntityBase<TId>
    where TId : ValueObject
{
    Task AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken);
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken);
    Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken);
    Task<bool> IsUniqueAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
}
