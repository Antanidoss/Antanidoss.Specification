using LinqKit;
using Antanidoss.Specification.Abstract;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Implementation.Specifications
{
    public class EmptySpecification<TEntity> : Specification<TEntity>
        where TEntity : class
    {
        private readonly bool _defaultExpressionResult;

        public EmptySpecification(bool defaultExpressionResult)
        {
            _defaultExpressionResult = defaultExpressionResult;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            return PredicateBuilder.New<TEntity>(_defaultExpressionResult);
        }
    }
}
