using System.Collections.Generic;
using System.Linq;

namespace GreekFire.Foundation.ChangeSets
{
    /// <summary>
    /// Implements IChangeSet.
    /// Used by the MemoryDataContext to keep track of changes before commit
    /// </summary>
    public class ChangeSet : IChangeSet
    {
        private readonly List<object> _itemsToDelete = new List<object>();
        private readonly List<object> _itemsToInsert = new List<object>();
        private readonly List<object> _itemsToUpdate = new List<object>();

        /// <summary>
        /// Adds an item to be deleted.
        /// </summary>
        /// <param name="itemToDelete">The item to delete.</param>
        public IChangeSet AddDelete(object itemToDelete)
        {
            _itemsToDelete.Add(itemToDelete);

            return this;
        }

        /// <summary>
        /// Adds an item to be inserted.
        /// </summary>
        /// <param name="itemToInsert">The item to insert.</param>
        public IChangeSet AddInsert(object itemToInsert)
        {
            _itemsToInsert.Add(itemToInsert);

            return this;
        }

        /// <summary>
        /// Adds an item to be updated.
        /// </summary>
        /// <param name="itemToUpdate">The item to update.</param>
        public IChangeSet AddUpdate(object itemToUpdate)
        {
            _itemsToUpdate.Add(itemToUpdate);

            return this;
        }

        /// <summary>
        /// Returns the Deletes in an IQueryable<typeparam name="T"></typeparam>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetDeletes<T>()
        {
            IEnumerable<object> query = from objects in _itemsToDelete
                                        where typeof (T).IsAssignableFrom(objects.GetType())
                                        select objects;

            return query.Select(o => (T) o).AsQueryable();
        }

        /// <summary>
        /// Returns the Inserts in an IQueryable<typeparam name="T"></typeparam>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetInserts<T>()
        {
            IEnumerable<object> query = from objects in _itemsToInsert
                                        where typeof (T).IsAssignableFrom(objects.GetType())
                                        select objects;

            return query.Select(o => (T) o).AsQueryable();
        }

        /// <summary>
        /// Returns the Updates in an IQueryable<typeparam name="T"></typeparam>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetUpdates<T>()
        {
            IEnumerable<object> query = from objects in _itemsToUpdate
                                        where typeof (T).IsAssignableFrom(objects.GetType())
                                        select objects;

            return query.Select(o => (T) o).AsQueryable();
        }

        /// <summary>
        /// Resets the ChangeSet clearing all the inserts.
        /// </summary>
        public IChangeSet Reset()
        {
            _itemsToInsert.Clear();
            _itemsToUpdate.Clear();
            _itemsToDelete.Clear();

            return this;
        }
    }
}