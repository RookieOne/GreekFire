using System;
using System.Windows.Input;
using AutoMapper;
using GreekFire.Client.Infrastructure.Attributes;
using GreekFire.Client.Infrastructure.ViewModels;
using GreekFire.Domain;
using Microsoft.Practices.Composite.Wpf.Commands;
using Microsoft.Practices.Unity;

namespace GreekFire.Client.Module.Expenses.ViewModels
{
    /// <summary>
    /// Implements IEditExpenseViewModel
    /// Allows editting of an existing Expense or a newly created Expense
    /// </summary>
    [UnityRegister(typeof (IEditExpenseViewModel))]
    public class EditExpenseViewModel : ViewModel, IEditExpenseViewModel
    {
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the save command.
        /// </summary>
        /// <value>The save command.</value>
        public ICommand Save { get; set; }

        public string Title { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EditExpenseViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public EditExpenseViewModel(IUnityContainer container) : base(container)
        {
            Save = new DelegateCommand<object>(OnSave);
        }

        /// <summary>
        /// Called when [save].
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void OnSave(object parameter)
        {
        }

        /// <summary>
        /// Raises the saved event.
        /// </summary>
        private void RaiseSaved()
        {
            EventHandler handler = Saved;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Creates a new expense.
        /// </summary>
        public void CreateExpense()
        {
            var expenseDto = new ExpenseDto();
            Mapper.Map(expenseDto, this);
        }

        /// <summary>
        /// Edits the expense.
        /// </summary>
        /// <param name="expense">The expense.</param>
        public void EditExpense(ExpenseDto expense)
        {
            Mapper.Map(expense, this);
        }

        /// <summary>
        /// Occurs when [saved].
        /// </summary>
        public event EventHandler Saved;
    }
}