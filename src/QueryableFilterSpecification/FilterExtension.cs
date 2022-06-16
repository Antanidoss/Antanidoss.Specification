using QueryableFilterSpecification.Implementation;
using QueryableFilterSpecification.Interfaces;

namespace QueryableFilterSpecification
{
    public static class FilterExtension
    {
        public static IQueryableFilterSpec<TEntityType> And<TEntityType>(this IQueryableFilterSpec<TEntityType> firstFilter, IQueryableFilterSpec<TEntityType> secondFilter)
            where TEntityType : class
        {
            return new AndIQueryableFilterSpec<TEntityType>(firstFilter, secondFilter);
        }

        public static IQueryableFilterSpec<TEntityType> Or<TEntityType>(this IQueryableFilterSpec<TEntityType> firstFilter, IQueryableFilterSpec<TEntityType> secondFilter)
            where TEntityType : class
        {
            return new OrIQueryableFilterSpec<TEntityType>(firstFilter, secondFilter);
        }

        public static IQueryableFilterSpec<TEntityType> WrapInBrackets<TEntityType>(this IQueryableFilterSpec<TEntityType> filter)
            where TEntityType : class
        {
            return new WrapBracketsIQueryableFilterSpec<TEntityType>(filter);
        }
    }
}
