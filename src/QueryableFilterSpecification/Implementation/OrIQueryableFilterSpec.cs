using LinqKit;
using QueryableFilterSpecification.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation
{
    public class OrIQueryableFilterSpec<TEntityType> : IQueryableFilterSpec<TEntityType>
        where TEntityType : class
    {
        private readonly IQueryableFilterSpec<TEntityType> _firstFilter;

        private readonly IQueryableFilterSpec<TEntityType> _secondFilter;

        public OrIQueryableFilterSpec(IQueryableFilterSpec<TEntityType> firstFilter, IQueryableFilterSpec<TEntityType> secondFilter)
        {
            _firstFilter = firstFilter;
            _secondFilter = secondFilter;
        }

        public IQueryable<TEntityType> ApplyFilter(IQueryable<TEntityType> entities)
        {
            return entities.Where(ToExpression());
        }

        public Expression<Func<TEntityType, bool>> ToExpression()
        {
            if (_firstFilter == null) return _secondFilter.ToExpression();
            else if (_secondFilter == null) return _firstFilter.ToExpression();

            return _firstFilter.ToExpression().Or(_secondFilter.ToExpression());
        }
    }
}
