using LinqKit;
using Antanidoss.Specification.Interfaces;
using Antanidoss.Specification.Validations;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    public class WrapBracketsSpecification<TEntity> : ISpecification<TEntity>
        where TEntity : class
    {
        private readonly ISpecification<TEntity> _specification;

        public WrapBracketsSpecification(ISpecification<TEntity> specification)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(specification);

            _specification = specification;
        }

        public Expression<Func<TEntity, bool>> ToExpression()
        {
            Expression<Func<TEntity, bool>> expression = e => _specification.ToExpression().Invoke(e);

            return expression.Expand();
        }
    }
}
