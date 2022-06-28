using QueryableFilterSpecification.Interfaces;
using System;
using System.Linq;

namespace QueryableFilterSpecification.Implementation.Filters
{
    public class Where<TEntity> : IQueryableMultipleResultFilter<TEntity>
        where TEntity : class
    {
        public IQueryable<TEntity> ApplyFilter(ISpecification<TEntity> specification, IQueryable<TEntity> entities)
        {
            return entities.Where(specification.ToExpression());
        }
    }
}
