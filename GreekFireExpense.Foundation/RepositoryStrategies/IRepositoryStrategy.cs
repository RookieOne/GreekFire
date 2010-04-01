using System;
using System.Linq;
using System.Linq.Expressions;
using GreekFire.Foundation.Specifications;

namespace GreekFire.Foundation.RepositoryStrategies
{
    /// <summary>
    /// Inteface for Repostiory Strategies
    /// Repository Strategies abstract the persistience logic
    /// from the domain repository logic 
    /// </summary>    
    public interface IRepositoryStrategy : IDisposable
    {
        /// <summary>
        /// Gets all the entities.
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll<T>();

        /// <summary>
        /// Saves the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Save<T>(T entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Delete<T>(T entity);

        IQueryable<T> Where<T>(ISpecification<T> specification);

        /// <summary>
        /// Commits this strategy to the database.
        /// </summary>
        void Commit();
    }
}