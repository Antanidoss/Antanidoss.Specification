using LinqKit;
using Antanidoss.Specification.Interfaces;
using Antanidoss.Specification.Validations;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    internal class NotSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> _specification;

        public NotSpecification(ISpecification<TEntity> filter)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(filter);

            _specification = filter;
        }

        public Expression<Func<TEntity, bool>> ToExpression()
        {
            return _specification.ToExpression().Not();
        }
    }
}
