using LinqKit;
using QueryableFilterSpecification.Interfaces;
using QueryableFilterSpecification.Validations;
using System;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation.Specifications
{
    internal class NotSpecification<TEntityType> : ISpecification<TEntityType>
        where TEntityType : class
    {
        private readonly ISpecification<TEntityType> _specification;

        public NotSpecification(ISpecification<TEntityType> filter)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(filter);

            _specification = filter;
        }

        public Expression<Func<TEntityType, bool>> ToExpression()
        {
            return _specification.ToExpression().Not();
        }
    }
}
