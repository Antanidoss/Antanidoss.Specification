using Antanidoss.Specification.Builders;
using System;
using System.Linq.Expressions;

namespace Antanidoss.Specification.Abstract
{
    public abstract class Specification<TEntity>
        where TEntity : class
    {
        public abstract Expression<Func<TEntity, bool>> ToExpression();

        public static Specification<TEntity> operator |(Specification<TEntity> first, Specification<TEntity> second)
        {
            return first.Or(second);
        }

        public static Specification<TEntity> operator &(Specification<TEntity> first, Specification<TEntity> second)
        {
            return first.And(second);
        }

        public static implicit operator Expression<Func<TEntity, bool>>(Specification<TEntity> specification)
        {
            return specification.ToExpression();
        }
    }
}
