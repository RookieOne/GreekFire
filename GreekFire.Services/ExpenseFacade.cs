using System;
using System.Collections.Generic;
using System.ServiceModel;
using GreekFire.Domain;

namespace GreekFire.Services
{
    /// <summary>
    /// Expense Wcf Service
    /// </summary>
    [ServiceContract]
    public class ExpenseFacade : IExpenseFacade
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseFacade"/> class.
        /// </summary>
        public ExpenseFacade()
        {
            UnitOfWorkConfig.Build();
        }

        /// <summary>
        /// Gets all the expenses.
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        public IEnumerable<ExpenseDto> GetExpenses()
        {
            var service = new ExpenseService();

            return service.GetExpenses();
        }

        public void SaveExpense(ExpenseDto expenseDto)
        {
            throw new NotImplementedException();
        }

        public void ApproveExpense(int id, DateTime approvalDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ExpenseDto> GetAllApprovedExpenses()
        {
            throw new NotImplementedException();
        }
    }
}