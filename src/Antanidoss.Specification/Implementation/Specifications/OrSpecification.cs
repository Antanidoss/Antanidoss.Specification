using LinqKit;
using Antanidoss.Specification.Interfaces;
using Antanidoss.Specification.Validations;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    public class OrSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> _firstSpecification;

        private readonly ISpecification<TEntity> _secondSpecification;

        public OrSpecification(ISpecification<TEntity> firstSpecification, ISpecification<TEntity> secondSpecification)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(firstSpecification);
            SpecificationValidations.ThowExepceptionIfSpecificationNull(secondSpecification);

            _firstSpecification = firstSpecification;
            _secondSpecification = secondSpecification;
        }

        public Expression<Func<TEntity, bool>> ToExpression()
        {
            return _firstSpecification.ToExpression().Or(_secondSpecification.ToExpression());
        }
    }
}
