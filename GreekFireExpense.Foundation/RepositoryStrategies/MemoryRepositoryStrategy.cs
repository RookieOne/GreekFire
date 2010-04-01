using System.Collections.Generic;
using System.Linq;
using GreekFire.Foundation.Specifications;

namespace GreekFire.Foundation.RepositoryStrategies
{
    public class MemoryRepositoryStrategy : IRepositoryStrategy
    {
        public List<object> _memoryStore;

        public MemoryRepositoryStrategy()
        {
            _memoryStore = new List<object>();
        }

        public IQueryable<T> GetAll<T>()
        {
            IEnumerable<object> query = from objects in _memoryStore
                                        where typeof (T).IsAssignableFrom(objects.GetType())
                                        select objects;

            return query.Select(o => (T) o).AsQueryable();
        }

        public void Save<T>(T entity)
        {
            _memoryStore.Add(entity);
        }

        public void Delete<T>(T entity)
        {
            _memoryStore.Remove(entity);
        }

        public void Commit()
        {
            // do nothing
        }

        public void Dispose()
        {
        }

        public IQueryable<T> Where<T>(ISpecification<T> spec)
        {
            IEnumerable<object> query = from objects in _memoryStore
                                        where typeof (T).IsAssignableFrom(objects.GetType())
                                        select objects;

            IQueryable<T> queryT = query.Select(o => (T) o).AsQueryable();

            return spec.SatisfyingElementsFrom(queryT);
        }
    }
}