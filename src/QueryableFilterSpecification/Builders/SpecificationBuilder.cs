using QueryableFilterSpecification.Implementation.Specifications;
using QueryableFilterSpecification.Interfaces;

namespace QueryableFilterSpecification.Builders
{
    public class SpecificationBuilder<TFilterType, TEntityType>
        where TEntityType : class
    {
        private ISpecification<TEntityType> filterSpec { get; set; }

        public SpecificationBuilder(ISpecification<TEntityType> filterSpec)
        {
            this.filterSpec = filterSpec;
        }

        public SpecificationBuilder<TFilterType, TEntityType> And(ISpecification<TEntityType> firstFilter, ISpecification<TEntityType> secondFilter)
        {
            filterSpec = new AndSpecification<TEntityType>(firstFilter, secondFilter);

            return this;
        }

        public SpecificationBuilder<TFilterType, TEntityType> Or(ISpecification<TEntityType> firstFilter, ISpecification<TEntityType> secondFilter)
        {
            filterSpec = new OrSpecification<TEntityType>(firstFilter, secondFilter);

            return this;
        }

        public SpecificationBuilder<TFilterType, TEntityType> WrapInBrackets(ISpecification<TEntityType> filter)
        {
            filterSpec = new WrapBracketsSpecification<TEntityType>(filter);

            return this;
        }

        public SpecificationBuilder<TFilterType, TEntityType> Not(ISpecification<TEntityType> filter)
        {
            filterSpec = new NotSpecification<TEntityType>(filter);

            return this;
        }
    }
}
