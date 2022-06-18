using LinqKit;
using QueryableFilterSpecification.Interfaces;
using QueryableFilterSpecification.Validations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation
{
    internal class NotIQueryableFilterSpec<TEntityType> : IQueryableFilterSpec<TEntityType>
        where TEntityType : class
    {
        private readonly IQueryableFilterSpec<TEntityType> _filter;

        public NotIQueryableFilterSpec(IQueryableFilterSpec<TEntityType> filter)
        {
            FilterValidations.ThowExepceptionIfFilterNull(filter);

            _filter = filter;
        }

        public IQueryable<TEntityType> ApplyFilter(IQueryable<TEntityType> entities)
        {
            return entities.Where(ToExpression());
        }

        public Expression<Func<TEntityType, bool>> ToExpression()
        {
            return _filter.ToExpression().Not();
        }
    }
}
