using System;
using System.Collections.Generic;
using System.Linq;

namespace GreekFireExpense.Data.DataContexts
{
    /// <summary>
    /// Memory Data Context implements IDataContext and uses
    /// an in memory data store
    /// </summary>
    public class MemoryDataContext : IDataContext
    {
        #region Properties

        private List<object> MemoryDataStore { get; set; }

        private ChangeSet _changeSet;
        public IChangeSet ChangeSet
        {
            get { return _changeSet; }            
        }        

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryDataContext"/> class.
        /// </summary>
        public MemoryDataContext()
        {
            _changeSet = new ChangeSet();
            MemoryDataStore = new List<object>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Repositories for entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> Repository<T>() where T : class
        {
            IEnumerable<object> query = from objects in MemoryDataStore
                                        where typeof (T).IsAssignableFrom(objects.GetType())
                                        select objects;


            return query.Select(o => (T) o).AsQueryable();
        }

        /// <summary>
        /// Adds the item to the list of items to be inserted upon commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public void Save<T>(T item) where T : class
        {
            var foundItem = Repository<T>().Where(i => i == item).FirstOrDefault();

            if (foundItem == null)
            {
                _changeSet.AddInsert(item);
                MemoryDataStore.Add(item);
            }
            else
            {
                _changeSet.AddUpdate(item);                
            }
        }

        /// <summary>
        /// Adds the item to the list of items to be deleted upon commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        public void Delete<T>(T item) where T : class
        {
            _changeSet.AddDelete(item);
            MemoryDataStore.Remove(item);
        }

        /// <summary>
        /// Commits the current unit of work to the database.
        /// </summary>
        public void Commit()
        {
            _changeSet.Reset();
            RaiseCompleted(EventArgs.Empty);
        }

        #endregion

        #region Completed Event 

        public event EventHandler Completed;

        /// <summary>
        /// Raises the completed event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RaiseCompleted(EventArgs e)
        {
            EventHandler completedHandler = Completed;

            if (completedHandler != null)
                completedHandler(this, e);
        }

        #endregion
    }
}