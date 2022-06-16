using LinqKit;
using QueryableFilterSpecification.Interfaces;
using QueryableFilterSpecification.Validations;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation
{
    public class WrapBracketsIQueryableFilterSpec<TEntityType> : IQueryableFilterSpec<TEntityType>
        where TEntityType : class
    {
        private readonly IQueryableFilterSpec<TEntityType> _filter;

        public WrapBracketsIQueryableFilterSpec(IQueryableFilterSpec<TEntityType> filter)
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
            return PredicateBuilder.New<TEntityType>(e => (_filter.ToExpression().Compile().Invoke(e)));
        }
    }
}
