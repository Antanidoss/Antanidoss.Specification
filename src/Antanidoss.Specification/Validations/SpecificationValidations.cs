using Antanidoss.Specification.Abstract;
using System;

namespace Antanidoss.Specification.Validations
{
    internal static class SpecificationValidations
    {
        public static void ThowExepceptionIfSpecificationNull<TEntity>(Specification<TEntity> specification)
            where TEntity : class
        {
            if (specification is null)
                throw new ArgumentNullException($"{nameof(specification)} cannot be null");
        }
    }
}
