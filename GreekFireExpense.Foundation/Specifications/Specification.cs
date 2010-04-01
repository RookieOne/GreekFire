using System.Linq;

namespace GreekFire.Foundation.Specifications
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public bool IsSatisfiedBy(T item)
        {
            return SatisfyingElementsFrom(new[] {item}.AsQueryable()).Any();
        }

        public abstract IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates);
    }
}