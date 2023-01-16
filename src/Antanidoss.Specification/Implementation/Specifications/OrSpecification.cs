using LinqKit;
using Antanidoss.Specification.Abstract;
using Antanidoss.Specification.Validations;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    public class OrSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly Specification<TEntity> _firstSpecification;

        private readonly Specification<TEntity> _secondSpecification;

        public OrSpecification(Specification<TEntity> firstSpecification, Specification<TEntity> secondSpecification)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(firstSpecification);
            SpecificationValidations.ThowExepceptionIfSpecificationNull(secondSpecification);

            _firstSpecification = firstSpecification;
            _secondSpecification = secondSpecification;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return _firstSpecification.ToExpression().Or(_secondSpecification);
        }
    }
}
