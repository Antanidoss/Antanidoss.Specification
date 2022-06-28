using System;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Interfaces
{
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> ToExpression();
    }
}
