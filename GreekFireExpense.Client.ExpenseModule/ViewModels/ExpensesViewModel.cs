using System.Collections.Generic;
using System.Windows.Input;
using GreekFire.Client.Infrastructure.Attributes;
using GreekFire.Client.Infrastructure.ViewModels;
using GreekFire.Domain;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Composite.Wpf.Commands;
using Microsoft.Practices.Unity;

namespace GreekFire.Client.Module.Expenses.ViewModels
{
    /// <summary>
    /// Implements IExpensesViewModel.
    /// Displays All Expenses
    /// </summary>
    [UnityRegister(typeof (IExpensesViewModel))]
    public class ExpensesViewModel : ViewModel, IExpensesViewModel
    {
        public IEnumerable<ExpenseDto> Expenses { get; set; }

        private ExpenseDto SelectedExpense { get; set; }

        /// <summary>
        /// Gets the create command.
        /// </summary>
        /// <value>The create command.</value>
        public ICommand Create { get; set; }

        /// <summary>
        /// Gets the edit command.
        /// </summary>
        /// <value>The edit command.</value>
        public ICommand Edit { get; set; }

        /// <summary>
        /// Gets the edit region.
        /// </summary>
        /// <value>The edit region.</value>
        private IRegion EditRegion
        {
            get
            {
                if (RegionManager != null)
                {
                    return RegionManager.Regions["EditRegion"];
                }
                return null;
            }
        }

        [Dependency]
        private IExpenseService Service { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpensesViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ExpensesViewModel(IUnityContainer container) : base(container)
        {
            Edit = new DelegateCommand<object>(OnEdit);
            Create = new DelegateCommand<object>(OnCreate);
            LoadExpenses();
        }

        /// <summary>
        /// Loads the expenses.
        /// </summary>
        private void LoadExpenses()
        {
            Expenses = Service.GetExpenses();            
        }

        private void OnCreate(object parameter)
        {
            if (EditRegion != null)
            {
                var editModel = Container.Resolve<IEditExpenseViewModel>();
                editModel.CreateExpense();
                editModel.Saved += (sender, e) =>
                                       {
                                           EditRegion.Remove(editModel);
                                           LoadExpenses();
                                       };

                EditRegion.Add(editModel);
            }
        }

        private void OnEdit(object parameter)
        {
            if (SelectedExpense != null && EditRegion != null)
            {
                var editModel = Container.Resolve<IEditExpenseViewModel>();
                editModel.EditExpense(SelectedExpense);
                editModel.Saved += (sender, e) =>
                                       {
                                           EditRegion.Remove(editModel);
                                           LoadExpenses();
                                       };

                EditRegion.Add(editModel);
            }
        }
    }
}