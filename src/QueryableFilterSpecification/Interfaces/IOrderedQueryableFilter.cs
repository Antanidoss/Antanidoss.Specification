using System.Linq;

namespace QueryableFilterSpecification.Interfaces
{
    public interface IOrderedQueryableFilter<TEntity>
        where TEntity : class
    {
        IOrderedQueryable<TEntity> ApplyFilter(IQueryable<TEntity> entities);
    }
}
