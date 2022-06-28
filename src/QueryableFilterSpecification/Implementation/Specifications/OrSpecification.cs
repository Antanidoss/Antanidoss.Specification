using LinqKit;
using QueryableFilterSpecification.Interfaces;
using QueryableFilterSpecification.Validations;
using System;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation.Specifications
{
    public class OrSpecification<TEntityType> : ISpecification<TEntityType>
        where TEntityType : class
    {
        private readonly ISpecification<TEntityType> _firstSpecification;

        private readonly ISpecification<TEntityType> _secondSpecification;

        public OrSpecification(ISpecification<TEntityType> firstSpecification, ISpecification<TEntityType> secondSpecification)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(firstSpecification);
            SpecificationValidations.ThowExepceptionIfSpecificationNull(secondSpecification);

            _firstSpecification = firstSpecification;
            _secondSpecification = secondSpecification;
        }

        public Expression<Func<TEntityType, bool>> ToExpression()
        {
            return _firstSpecification.ToExpression().Or(_secondSpecification.ToExpression());
        }
    }
}
