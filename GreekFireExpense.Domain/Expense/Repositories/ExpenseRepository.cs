using System.Collections.Generic;
using System.Linq;
using GreekFire.Foundation.RepositoryStrategies;
using GreekFire.Foundation.Specifications;
using GreekFire.Foundation.UnitOfWorks;
using Microsoft.Practices.Unity;

namespace GreekFire.Domain
{
    /// <summary>
    /// The Expense Repository controls all persistence operations surrounding Expense
    /// </summary>
    public class ExpenseRepository
    {
        private readonly IRepositoryStrategy _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseRepository"/> class.
        /// The Repository Strategy is identified as the ExpenseDatabase in the Unity Container        
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <param name="strategyRegister">The strategy register.</param>
        [InjectionConstructor]
        public ExpenseRepository([Dependency("ExpenseDatabase")] IRepositoryStrategy strategy,
                                 IStrategyRegister strategyRegister)
        {
            _database = strategy;
            strategyRegister.Register(strategy);
        }

        /// <summary>
        /// Gets all the expenses.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ExpenseDto> GetExpenses()
        {
            return _database.GetAll<ExpenseDto>().ToList();
        }

        /// <summary>
        /// Saves the expense.
        /// </summary>
        /// <param name="expense">The expense.</param>
        public void Save(Expense expense)
        {
            _database.Save(expense.ToDto());
        }

        public ExpenseDto GetExpense(int id)
        {
            return _database.Where(HasIntId<ExpenseDto>.Of(id)).FirstOrDefault();
        }

        public IEnumerable<ExpenseDto> GetApprovedExpenses()
        {
            return _database.Where(IsApprovedExpense.Create());
        }
    }
}