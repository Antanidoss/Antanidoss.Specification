using LinqKit;
using QueryableFilterSpecification.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation
{
    public class EmptyQueryableFilterSpec<TEntityType> : IQueryableFilterSpec<TEntityType>
        where TEntityType : class
    {
        public IQueryable<TEntityType> ApplyFilter(IQueryable<TEntityType> entities)
        {
            return entities.Where(ToExpression());
        }

        public Expression<Func<TEntityType, bool>> ToExpression()
        {
            return PredicateBuilder.New<TEntityType>();
        }
    }
}
