using System.Linq;

namespace QueryableFilterSpecification.Interfaces
{
    public interface IQueryableSingleResultFilter<TEntity>
        where TEntity : class
    {
        TEntity ApplyFilter(ISpecification<TEntity> specification, IQueryable<TEntity> entities);
    }
}
