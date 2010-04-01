using System.Windows;
using GreekFire.Client.Module.Expenses;
using GreekFire.Client.Shell.ViewModels;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.UnityExtensions;
using Microsoft.Practices.Unity;

namespace GreekFire.Client.Shell
{
    /// <summary>
    /// Bootstrapper for the Wpf Prism Client App for GreekFireExpense
    /// </summary>
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Create Shell Window and call show()
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            var shellWindow = new ShellWindow();

            var c = Container.Resolve<IUnityContainer>();
            shellWindow.Content = Container.Resolve<ShellViewModel>();
            shellWindow.Show();

            return shellWindow;
        }

        /// <summary>
        /// Returns the module enumerator that will be used to initialize the modules.
        /// </summary>
        /// <returns>
        /// An instance of <see cref="IModuleEnumerator"/> that will be used to initialize the modules.
        /// </returns>
        /// <remarks>
        /// When using the default initialization behavior, this method must be overwritten by a derived class.
        /// </remarks>
        protected override IModuleEnumerator GetModuleEnumerator()
        {
            return new StaticModuleEnumerator().AddModule(typeof (ExpenseModule));
        }
    }
}