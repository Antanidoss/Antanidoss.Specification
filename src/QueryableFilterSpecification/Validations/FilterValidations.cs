using QueryableFilterSpecification.Interfaces;
using System;

namespace QueryableFilterSpecification.Validations
{
    internal static class FilterValidations
    {
        public static void ThowExepceptionIfFilterNull<TEntityType>(IQueryableFilterSpec<TEntityType> filter)
            where TEntityType : class
        {
            if (filter is null)
                throw new ArgumentNullException($"{nameof(filter)} cannot be null");
        }
    }
}
