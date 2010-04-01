using System;
using GreekFire.Client.Infrastructure.ViewModels;
using GreekFire.Domain;

namespace GreekFire.Client.Module.Expenses.ViewModels
{
    /// <summary>
    /// Interface for Edit Expense ViewModel
    /// Allows creation and editting of expenses
    /// </summary>
    public interface IEditExpenseViewModel : IViewModel
    {
        /// <summary>
        /// Creates the expense.
        /// </summary>
        void CreateExpense();

        /// <summary>
        /// Edits the expense.
        /// </summary>
        /// <param name="expense">The expense.</param>
        void EditExpense(ExpenseDto expense);

        /// <summary>
        /// Occurs when [saved].
        /// </summary>
        event EventHandler Saved;
    }
}