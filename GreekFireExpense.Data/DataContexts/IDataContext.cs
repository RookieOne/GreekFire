using System.Linq;

namespace GreekFireExpense.Data.DataContexts
{
    /// <summary>
    /// Interface for the DataContext which acts as a Unit of Work
    /// Abstracts inserts into the database and provides repositories for Entities
    /// </summary>
    public interface IDataContext
    {
        /// <summary>
        /// Gets the current change set for the unit of work.
        /// </summary>
        /// <value>The change set.</value>
        IChangeSet ChangeSet { get; }

        /// <summary>
        /// Repositories for entities
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IQueryable<T> Repository<T>() where T : class;

        /// <summary>
        /// Saves the item to the list of items to be inserted or updated upon commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Save<T>(T item) where T : class;

        /// <summary>
        /// Adds the item to the list of items to be deleted upon commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        void Delete<T>(T item) where T : class;

        /// <summary>
        /// Commits the current unit of work to the database.
        /// </summary>
        void Commit();
    }
}
