using GreekFire.Client.Infrastructure.Aspects;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace GreekFire.Client.Infrastructure.ViewModels
{
    /// <summary>
    /// Base abstract class for all ViewModels. Implements IViewModel.    
    /// Also provides a UnityContainer and a RegionManager resolved by Unity
    /// during construction    
    /// </summary>
    [NotifyPropertyChanged]
    public abstract class ViewModel : IViewModel
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        protected IUnityContainer Container { get; set; }

        /// <summary>
        /// Gets or sets the region manager.
        /// </summary>
        /// <value>The region manager.</value>
        protected IRegionManager RegionManager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        protected ViewModel(IUnityContainer container)
        {
            Container = container;
            RegionManager = Container.Resolve<IRegionManager>();
        }
    }
}