namespace GreekFireExpense.Data.EntityFramework.Test.Repositories.ExpenseRepositoryTests
{
    using DataContexts;

    using Domain.Entities;

    using Foundation.Repositories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhenNewExpenseSavedAndComitted
    {
        private EntityFrameworkDataContext DataContext
        {
            get;
            set;
        }

        private Expense Expense
        {
            get;
            set;
        }

        [TestInitialize]
        public void Initialize()
        {
            this.DataContext = new EntityFrameworkDataContext();

            this.Expense = new Expense {Amount = 1000, Description = "Description", Title = "Title"};

            IRepository<Expense> repository = this.DataContext.GetRepository<Expense>();

            repository.Save(this.Expense);

            this.DataContext.Commit();
        }

        [TestCleanup]
        public void Cleanup()
        {
            foreach (ExpenseTable item in this.DataContext.Database.ExpenseTable)
            {
                this.DataContext.Database.DeleteObject(item);
            }
            this.DataContext.Database.SaveChanges();
        }

        [TestMethod]
        public void Should_add_entity_to_database()
        {
            var database = new EntityFrameworkDataContext();
            IRepository<Expense> repository = database.GetRepository<Expense>();
            Expense foundExpense = repository.GetById(this.Expense.Id);

            Assert.IsNotNull(foundExpense);
            Assert.AreEqual(this.Expense, foundExpense);
        }
    }
}