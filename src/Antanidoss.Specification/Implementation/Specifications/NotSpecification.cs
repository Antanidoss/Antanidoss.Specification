using LinqKit;
using Antanidoss.Specification.Abstract;
using Antanidoss.Specification.Validations;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    internal class NotSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly Specification<TEntity> _specification;

        public NotSpecification(Specification<TEntity> filter)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(filter);

            _specification = filter;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return _specification.ToExpression().Not();
        }
    }
}
