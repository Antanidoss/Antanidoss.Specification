using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Interfaces
{
    public interface IQueryableFilterSpec<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> entities);
        Expression<Func<TEntity, bool>> ToExpression();
    }
}
