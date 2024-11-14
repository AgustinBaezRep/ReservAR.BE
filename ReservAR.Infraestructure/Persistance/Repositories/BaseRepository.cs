using Microsoft.EntityFrameworkCore;
using ReservAR.Domain.Common.Models.Identities;
using ReservAR.Domain.Common.Models;
using System.Linq.Expressions;
using ReservAR.Application.Common.Interfaces.IRepositories;

namespace ReservAR.Infraestructure.Persistance.Repositories;


internal abstract class RepositoryBase<TEntity, TId>(ReservarDbContext transferPricingDbContext) : IRepositoryBase<TEntity, TId>
    where TEntity : AggregateRoot<TId>
    where TId : AggregateRootId
{
    protected DbSet<TEntity> DbSet { get; } = transferPricingDbContext.Set<TEntity>();
    protected IQueryable<TEntity> DbQuery { get; } = transferPricingDbContext.Set<TEntity>().AsQueryable().AsNoTracking();

    public async Task AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await transferPricingDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await DbSet.AddRangeAsync(entities, cancellationToken);
        await transferPricingDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Update(entity);
        await transferPricingDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(TEntity entity, CancellationToken cancellationToken)
    {
        DbSet.Remove(entity);
        await transferPricingDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        DbSet.RemoveRange(entities);
        await transferPricingDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(TId id, CancellationToken cancellationToken)
    {
        return await DbSet.Where(e => e.Id.Equals(id)).FirstOrDefaultAsync(cancellationToken);
    }

    protected IQueryable<TEntity> ApplySpecification(Specification<TEntity, TId> specification)
    {
        return SpecificationEvaluator.GetQuery(DbQuery, specification);
    }

    public async Task<bool> IsUniqueAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return !await DbQuery.AnyAsync(predicate, cancellationToken);
    }
}
