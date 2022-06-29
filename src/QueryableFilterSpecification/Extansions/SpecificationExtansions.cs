using Antanidoss.Specification.Implementation.Specifications;
using Antanidoss.Specification.Interfaces;

namespace Antanidoss.Specification.Builders
{
    public static class SpecificationExtansions
    {
        public static ISpecification<TEntityType> And<TEntityType>(this ISpecification<TEntityType> firstSpecification, ISpecification<TEntityType> secondSpecification)
            where TEntityType : class
        {
            return new AndSpecification<TEntityType>(firstSpecification, secondSpecification);
        }

        public static ISpecification<TEntityType> Or<TEntityType>(this ISpecification<TEntityType> firstSpecification, ISpecification<TEntityType> secondSpecification)
            where TEntityType : class
        {
            return new OrSpecification<TEntityType>(firstSpecification, secondSpecification);
        }

        public static ISpecification<TEntityType> WrapInBrackets<TEntityType>(this ISpecification<TEntityType> specification)
            where TEntityType : class
        {
            return new WrapBracketsSpecification<TEntityType>(specification);
        }

        public static ISpecification<TEntityType> Not<TEntityType>(this ISpecification<TEntityType> specification)
            where TEntityType : class
        {
            return new NotSpecification<TEntityType>(specification);
        }
    }
}
