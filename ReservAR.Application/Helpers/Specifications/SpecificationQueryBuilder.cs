namespace ReservAR.Application.Helpers.Specifications
{
    public static class SpecificationQueryBuilder
    {
        public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery,
                                                            Specification<TEntity> specification)
        {
            var query = inputQuery;

            if (specification.Criteria is not null)
            {
                query = query.Where(specification.Criteria);
            }

            if (specification.Includes is not null)
            {
                //TODO: chequear herencia de BaseEntity o AggregateRoot ya que el Include() no lo toma
                //query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (specification.OrderBy is not null)
            {
                query = query.OrderBy(specification.OrderBy);
            }

            if (specification.OrderByDesc is not null)
            {
                query = query.OrderByDescending(specification.OrderByDesc);
            }

            if (specification.IsSplitQuery)
            {
                //TODO: chequear herencia de BaseEntity o AggregateRoot ya que el AsSplitQuery() no lo toma
                //query = query.AsSplitQuery();
            }

            return query;
        }
    }
}