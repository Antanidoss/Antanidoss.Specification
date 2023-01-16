using Antanidoss.Specification.Implementation.Specifications;
using Antanidoss.Specification.Abstract;

namespace Antanidoss.Specification.Builders
{
    public static class SpecificationExtansions
    {
        public static Specification<TEntityType> And<TEntityType>(this Specification<TEntityType> firstSpecification, Specification<TEntityType> secondSpecification)
            where TEntityType : class
        {
            return new AndSpecification<TEntityType>(firstSpecification, secondSpecification);
        }

        public static Specification<TEntityType> Or<TEntityType>(this Specification<TEntityType> firstSpecification, Specification<TEntityType> secondSpecification)
            where TEntityType : class
        {
            return new OrSpecification<TEntityType>(firstSpecification, secondSpecification);
        }

        public static Specification<TEntityType> WrapInBrackets<TEntityType>(this Specification<TEntityType> specification)
            where TEntityType : class
        {
            return new WrapBracketsSpecification<TEntityType>(specification);
        }

        public static Specification<TEntityType> Not<TEntityType>(this Specification<TEntityType> specification)
            where TEntityType : class
        {
            return new NotSpecification<TEntityType>(specification);
        }
    }
}
