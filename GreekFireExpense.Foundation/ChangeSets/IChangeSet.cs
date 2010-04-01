using System.Linq;

namespace GreekFire.Foundation.ChangeSets
{
    /// <summary>
    /// Interface for a ChangeSet.
    /// The IChangeSet will keep track of what work is to be committed by
    /// the IDataContext.
    /// The IDataContext with the IChangeSet implements the Unit Of Work Pattern
    /// Also utilizes Fluent Interfaces for method chaining
    /// </summary>
    public interface IChangeSet
    {
        /// <summary>
        /// Returns the Inserts in an IQueryable<typeparam name="T"></typeparam>.
        /// </summary>
        IQueryable<T> GetInserts<T>();

        /// <summary>
        /// Returns the Updates in an IQueryable<typeparam name="T"></typeparam>.
        /// </summary>
        IQueryable<T> GetUpdates<T>();

        /// <summary>
        /// Returns the Deletes in an IQueryable<typeparam name="T"></typeparam>.
        /// </summary>
        IQueryable<T> GetDeletes<T>();
    }
}