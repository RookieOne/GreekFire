using System;
using System.Collections.Generic;
using GreekFire.Foundation.ChangeSets;
using GreekFire.Foundation.Extensions;
using GreekFire.Foundation.RepositoryStrategies;
using Microsoft.Practices.Unity;

namespace GreekFire.Foundation.UnitOfWorks
{
    /// <summary>
    /// Memory Data Context implements IDataContext and uses
    /// an in memory data store
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IStrategyRegister
    {
        private static IUnityContainer _container;
        private static QueryableContainerExtension _extension;
        private readonly ChangeSet _changeSet;
        private Dictionary<Type, IRepositoryStrategy> _strategies;

        /// <summary>
        /// Gets the current change set for the unit of work.
        /// </summary>
        /// <value>The change set.</value>
        public IChangeSet ChangeSet
        {
            get { return _changeSet; }
        }

        /// <summary>
        /// Gets or sets the repository unity container.        
        /// </summary>
        /// <value>The repository container.</value>
        private IUnityContainer RepositoryContainer { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        public UnitOfWork()
        {
            _changeSet = new ChangeSet();
            _strategies = new Dictionary<Type, IRepositoryStrategy>();

            RepositoryContainer = _container.CreateChildContainer();
            RepositoryContainer.RegisterInstance<IStrategyRegister>(this);
        }

        /// <summary>
        /// Gets the repository container.
        /// </summary>
        /// <returns>Unity Container for registering Repositories</returns>
        public static IUnityContainer GetRepositoryContainer()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
                _extension = new QueryableContainerExtension();
                _container.AddExtension(_extension);
            }

            return _container;
        }

        /// <summary>
        /// Commits the current unit of work to the database.
        /// </summary>
        public void Commit()
        {
            _changeSet.Reset();

            foreach (var strategy in _strategies.Values)
                strategy.Commit();
        }

        /// <summary>
        /// Disposes the unit of work
        /// </summary>
        public void Dispose()
        {
            _strategies.Values.ForEach(s => s.Dispose());
        }

        /// <summary>
        /// Gets the repository for the given entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetRepository<T>() where T : class 
        {            
            if (_extension.IsTypeRegistered<T, T>())
                return RepositoryContainer.Resolve<T>();

            return null;
        }

        /// <summary>
        /// Registers the specified strategy with the strategy register.
        /// Each unique strategy is stored in a collection. 
        /// The collection is used to notify strategies on commit and rollback
        /// of the unit of work
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns></returns>
        public IStrategyRegister Register(IRepositoryStrategy strategy)
        {
            Type strategyType = strategy.GetType();

            if (!_strategies.ContainsKey(strategyType))
                _strategies.Add(strategyType, strategy);

            return this;
        }
    }
}