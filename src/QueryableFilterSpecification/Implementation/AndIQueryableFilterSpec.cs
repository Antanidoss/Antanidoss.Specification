using LinqKit;
using QueryableFilterSpecification.Interfaces;
using QueryableFilterSpecification.Validations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation
{
    public class AndIQueryableFilterSpec<TEntityType> : IQueryableFilterSpec<TEntityType>
        where TEntityType : class
    {
        private readonly IQueryableFilterSpec<TEntityType> _firstFilter;

        private readonly IQueryableFilterSpec<TEntityType> _secondFilter;

        public AndIQueryableFilterSpec(IQueryableFilterSpec<TEntityType> firstFilter, IQueryableFilterSpec<TEntityType> secondFilter)
        {
            FilterValidations.ThowExepceptionIfFilterNull(firstFilter);
            FilterValidations.ThowExepceptionIfFilterNull(firstFilter);

            _firstFilter = firstFilter;
            _secondFilter = secondFilter;
        }

        public IQueryable<TEntityType> ApplyFilter(IQueryable<TEntityType> entities)
        {
            return entities.Where(ToExpression());
        }

        public Expression<Func<TEntityType, bool>> ToExpression()
        {
            return _firstFilter.ToExpression().And(_secondFilter.ToExpression());
        }
    }
}
