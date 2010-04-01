using System;
using System.Collections.Generic;

namespace GreekFire.Domain
{
    /// <summary>
    /// Interface for the Expense Service
    /// </summary>    
    public interface IExpenseService
    {
        /// <summary>
        /// Gets all the expenses.
        /// </summary>
        /// <returns></returns>        
        IEnumerable<ExpenseDto> GetExpenses();

        void SaveExpense(ExpenseDto expenseDto);

        void ApproveExpense(int id, DateTime approvalDate);

        IEnumerable<ExpenseDto> GetAllApprovedExpenses();
    }
}