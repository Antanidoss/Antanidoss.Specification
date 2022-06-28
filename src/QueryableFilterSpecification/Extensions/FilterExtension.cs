using QueryableFilterSpecification.Implementation.Filters;
using QueryableFilterSpecification.Interfaces;
using System.Linq;

namespace QueryableFilterSpecification.Extensions
{
    public static class FilterExtension
    {
        public static TEntity FirstOrDefault<TEntity>(this IQueryable<TEntity> entities, ISpecification<TEntity> specification)
            where TEntity : class
            
        {
            return new FirstOrDefault<TEntity>().ApplyFilter(specification, entities);
        }

        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> entities, ISpecification<TEntity> specification)
            where TEntity : class

        {
            return new Where<TEntity>().ApplyFilter(specification, entities);
        }
    }
}
