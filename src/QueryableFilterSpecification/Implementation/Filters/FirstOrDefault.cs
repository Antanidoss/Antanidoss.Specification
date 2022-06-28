using QueryableFilterSpecification.Interfaces;
using System.Linq;

namespace QueryableFilterSpecification.Implementation.Filters
{
    public class FirstOrDefault<TEntity> : IQueryableSingleResultFilter<TEntity>
        where TEntity : class
    {
        public TEntity ApplyFilter(ISpecification<TEntity> specification, IQueryable<TEntity> entities)
        {
            return entities.FirstOrDefault(specification.ToExpression());
        }
    }
}
