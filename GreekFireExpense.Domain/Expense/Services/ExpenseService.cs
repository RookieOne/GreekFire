using System;
using System.Collections.Generic;
using GreekFire.Foundation.UnitOfWorks;

namespace GreekFire.Domain
{
    /// <summary>
    /// Expense Wcf Service
    /// </summary>
    public class ExpenseService : IExpenseService
    {
        private ExpenseFactory _expenseFactory = new ExpenseFactory();

        /// <summary>
        /// Gets all the expenses.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExpenseDto> GetExpenses()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.GetRepository<ExpenseRepository>().GetExpenses();
            }
        }

        public void SaveExpense(ExpenseDto expenseDto)
        {
            var expense = _expenseFactory.createFromDto<Expense>(expenseDto);

            if (expense == null)
                return;

            using (var uow = new UnitOfWork())
            {
                uow.GetRepository<ExpenseRepository>().Save(expense);
            }
        }

        public void ApproveExpense(int id, DateTime approvalDate)
        {           
            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository<ExpenseRepository>();

                var dto = repository.GetExpense(id);

                var expense = _expenseFactory.createFromDto<NewExpense>(dto);

                if (expense != null)
                {
                    var approvedExpense = expense.Approve(approvalDate);
                    repository.Save(approvedExpense);
                }
            }
        }

        public IEnumerable<ExpenseDto> GetAllApprovedExpenses()
        {
            using (var uow = new UnitOfWork())
            {
                return uow.GetRepository<ExpenseRepository>().GetApprovedExpenses();
            }
        }
    }
}