using LinqKit;
using Antanidoss.Specification.Interfaces;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    public class EmptySpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        public Expression<Func<TEntity, bool>> ToExpression()
        {
            return PredicateBuilder.New<TEntity>();
        }
    }
}
