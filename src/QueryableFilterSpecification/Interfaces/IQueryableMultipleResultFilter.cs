using System.Linq;

namespace QueryableFilterSpecification.Interfaces
{
    public interface IQueryableMultipleResultFilter<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> ApplyFilter(ISpecification<TEntity> specification, IQueryable<TEntity> entities);
    }
}
