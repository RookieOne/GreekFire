using System.Linq;

namespace GreekFire.Foundation.Specifications
{
    public class HasIntId<T> : Specification<T>
    {
        private readonly int _id;

        private HasIntId(int id)
        {
            _id = id;
        }

        public static HasIntId<T> Of(int id)
        {
            return new HasIntId<T>(id);
        }

        public override IQueryable<T> SatisfyingElementsFrom(IQueryable<T> candidates)
        {
            return candidates
                .Cast<IHasIntId>()
                .Where(e => e.Id == _id)
                .Cast<T>();
        }
    }
}