using AutoMapper;
using GreekFire.Client.Infrastructure.Loaders;
using GreekFire.Client.Module.Expenses.ViewModels;
using GreekFire.Domain;
using GreekFireExpense.Client.Module.Expenses;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;

namespace GreekFire.Client.Module.Expenses
{
    /// <summary>
    /// Expense Module implment IExpenseModule
    /// </summary>
    public class ExpenseModule : IExpenseModule
    {
        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        private IUnityContainer Container { get; set; }

        /// <summary>
        /// Gets or sets the region manager.
        /// </summary>
        /// <value>The region manager.</value>
        private IRegionManager RegionManager { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        public ExpenseModule(IUnityContainer container, IRegionManager regionManager)
        {
            Container = container;
            RegionManager = regionManager;
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        private void RegisterServices()
        {
            Container.RegisterType<IExpenseService, ExpenseService>();            
        }

        /// <summary>
        /// Registers the view models.
        /// </summary>
        private void RegisterViewModels()
        {
            new AssemblyAttributeUnityLoader(GetType().Assembly).Register(Container);
        }

        /// <summary>
        /// Registers the views.
        /// </summary>
        private void RegisterViews()
        {
            new ResourceDictionaryLoader(GetType().Assembly).LoadResourceDictionaries();
        }

        /// <summary>
        /// Shows the default view.
        /// </summary>
        private void ShowDefaultView()
        {
            IRegion mainRegion = RegionManager.Regions["MainRegion"];
            mainRegion.Add(Container.Resolve<IExpensesViewModel>());
        }

        /// <summary>
        /// Creates and registers the maps with the Automapper.
        /// </summary>
        private void CreateMaps()
        {
            Mapper.CreateMap<ExpenseDto, EditExpenseViewModel>();
            Mapper.CreateMap<EditExpenseViewModel, ExpenseDto>();
        }

        /// <summary>
        /// Notifies the module that it has be initialized.
        /// </summary>
        public void Initialize()
        {
            RegisterViewModels();
            RegisterViews();
            RegisterServices();
            CreateMaps();

            ShowDefaultView();
        }
    }
}