using System;
using GreekFire.Foundation.ChangeSets;

namespace GreekFire.Foundation.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the current change set for the unit of work.
        /// </summary>
        /// <value>The change set.</value>
        IChangeSet ChangeSet { get; }

        /// <summary>
        /// Gets the repository for the given entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T GetRepository<T>() where T : class;

        /// <summary>
        /// Commits the current unit of work to the database.
        /// </summary>
        void Commit();        
    }
}