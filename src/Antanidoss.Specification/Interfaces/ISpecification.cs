using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Interfaces
{
    public interface ISpecification<TEntity>
        where TEntity : class
    {
        Expression<Func<TEntity, bool>> ToExpression();
    }
}
