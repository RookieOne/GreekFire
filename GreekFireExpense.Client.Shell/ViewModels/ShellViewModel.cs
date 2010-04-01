using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Wpf.Regions;

namespace GreekFire.Client.Shell.ViewModels
{
    /// <summary>
    /// Implements IShellViewModel.
    /// ViewModel for the Shell of the Application.
    /// Contains the regions for the shell of the application.
    /// </summary>
    public class ShellViewModel : IShellViewModel
    {
        /// <summary>
        /// Gets or sets the edit region.
        /// </summary>
        /// <value>The edit region.</value>
        public IRegion EditRegion { get; set; }

        /// <summary>
        /// Gets or sets the main region.
        /// </summary>
        /// <value>The main region.</value>
        public IRegion MainRegion { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public ShellViewModel(IRegionManager regionManager)
        {
            MainRegion = new Region();
            EditRegion = new SingleActiveRegion();
            regionManager.Regions.Add("MainRegion", MainRegion);
            regionManager.Regions.Add("EditRegion", EditRegion);
        }
    }
}