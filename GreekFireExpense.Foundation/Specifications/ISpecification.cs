using System.Linq;

namespace GreekFire.Foundation.Specifications
{
    public interface ISpecification<T>
    {
        bool IsSatisfiedBy(T item);
        IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates);
    }
}