using Microsoft.EntityFrameworkCore;
using ReservAR.Domain;
using ReservAR.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReservAR.Application.Common.Specifications
{
    public abstract class Specification<TEntity>
    {
        protected Specification() { }

        public Specification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }

        //TODO: agregar paginado y filtrado

        public bool IsSplitQuery { get; protected set; }
        public Expression<Func<TEntity, bool>> Criteria { get; }
        public List<Expression<Func<TEntity, object>>>? Includes { get; set; } = new();
        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDesc { get; private set; }

        protected void AddInclude(Expression<Func<TEntity, object>> includeExpression) =>
            Includes?.Add(includeExpression);

        protected void AddOrderBy(Expression<Func<TEntity, object>> orderByExpression) =>
            OrderBy = orderByExpression;

        protected void AddOrderByDesc(Expression<Func<TEntity, object>> orderByDescExpression) =>
            OrderByDesc = orderByDescExpression;
    }
}