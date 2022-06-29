using Antanidoss.Specification.Interfaces;
using System;

namespace Antanidoss.Specification.Validations
{
    internal static class SpecificationValidations
    {
        public static void ThowExepceptionIfSpecificationNull<TEntity>(ISpecification<TEntity> specification)
            where TEntity : class
        {
            if (specification is null)
                throw new ArgumentNullException($"{nameof(specification)} cannot be null");
        }
    }
}
