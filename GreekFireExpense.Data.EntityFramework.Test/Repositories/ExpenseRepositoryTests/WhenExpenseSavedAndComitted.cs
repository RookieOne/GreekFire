namespace GreekFireExpense.Data.EntityFramework.Test.Repositories.ExpenseRepositoryTests
{
    using DataContexts;

    using Domain.Entities;

    using Foundation.Repositories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhenExpenseSavedAndComitted
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

        private Expense UpdatedExpense
        {
            get;
            set;
        }

        [TestInitialize]
        public void Initialize()
        {
            using (var dc = new EntityFrameworkDataContext())
            {
                this.Expense = new Expense {Amount = 1000, Description = "Description", Title = "Title"};

                IRepository<Expense> repository = dc.GetRepository<Expense>();
                repository.Save(this.Expense);
                dc.Commit();
            }

            this.DataContext = new EntityFrameworkDataContext();

            IRepository<Expense> repository2 = this.DataContext.GetRepository<Expense>();
            this.UpdatedExpense = repository2.GetById(this.Expense.Id);
            this.UpdatedExpense.Amount = 500;
            this.UpdatedExpense.Title = "Updated";

            repository2.Save(this.UpdatedExpense);
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
        public void Should_update_entity_in_database()
        {
            var database = new EntityFrameworkDataContext();
            IRepository<Expense> repository = database.GetRepository<Expense>();
            Expense foundExpense = repository.GetById(this.UpdatedExpense.Id);

            Assert.IsNotNull(foundExpense);
            Assert.AreEqual(this.UpdatedExpense, foundExpense);
            Assert.AreNotEqual(this.Expense, foundExpense);
        }
    }
}