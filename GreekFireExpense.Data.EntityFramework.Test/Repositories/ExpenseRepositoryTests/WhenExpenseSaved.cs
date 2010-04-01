namespace GreekFireExpense.Data.EntityFramework.Test.Repositories.ExpenseRepositoryTests
{
    using System.Linq;

    using DataContexts;

    using Domain.Entities;

    using Foundation.Repositories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhenExpenseSaved
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
        }

        [TestMethod]
        public void Should_add_entity_to_be_updated()
        {
            Assert.AreEqual(1, this.DataContext.ChangeSet.GetUpdates<Expense>().Count());
            Assert.IsNotNull(
                    this.DataContext.ChangeSet.GetUpdates<Expense>().Where(e => e == this.UpdatedExpense).FirstOrDefault());
        }
    }
}