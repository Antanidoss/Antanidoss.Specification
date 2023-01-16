using LinqKit;
using Antanidoss.Specification.Abstract;
using Antanidoss.Specification.Validations;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    public class WrapBracketsSpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly Specification<TEntity> _specification;

        public WrapBracketsSpecification(Specification<TEntity> specification)
        {
            SpecificationValidations.ThowExepceptionIfSpecificationNull(specification);

            _specification = specification;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            Expression<Func<TEntity, bool>> expression = e => _specification.ToExpression().Invoke(e);

            return expression.Expand();
        }
    }
}
