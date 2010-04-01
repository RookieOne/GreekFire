namespace GreekFireExpense.Data.EntityFramework.Test.Mappings.ExpenseMappingTests
{
    using Domain.Entities;

    using EntityFramework.Mappings;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhenMapping
    {
        private EntityFrameworkMap Mapping
        {
            get;
            set;
        }

        [TestInitialize]
        public void Initialize()
        {
            this.Mapping = new EntityFrameworkMap();
        }

        [TestMethod]
        public void Expense_to_ExpenseTable_should_copy_all_values()
        {
            var expense = new Expense {Id = 1, Amount = 100, Title = "Title", Description = "Description"};
            ExpenseTable expenseTable = this.Mapping.GetDataEntity(expense);

            Assert.AreEqual(expense.Id, expenseTable.Id);
            Assert.AreEqual(expense.Amount, expenseTable.Amount);
            Assert.AreEqual(expense.Title, expenseTable.Title);
            Assert.AreEqual(expense.Description, expenseTable.Description);
        }

        [TestMethod]
        public void ExpenseTable_to_Expense_should_copy_all_values()
        {
            var expenseTable = new ExpenseTable {Id = 1, Amount = 100, Title = "Title", Description = "Description"};
            Expense expense = this.Mapping.GetEntity(expenseTable);

            Assert.AreEqual(expenseTable.Id, expense.Id);
            Assert.AreEqual(expenseTable.Amount, expense.Amount);
            Assert.AreEqual(expenseTable.Title, expense.Title);
            Assert.AreEqual(expenseTable.Description, expense.Description);
        }
    }
}