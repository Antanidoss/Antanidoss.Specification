using LinqKit;
using QueryableFilterSpecification.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QueryableFilterSpecification.Implementation.Specifications
{
    public class EmptySpecification<TEntityType> : ISpecification<TEntityType>
        where TEntityType : class
    {
        public Expression<Func<TEntityType, bool>> ToExpression()
        {
            return PredicateBuilder.New<TEntityType>();
        }
    }
}
