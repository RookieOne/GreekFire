namespace GreekFireExpense.Data.EntityFramework.Test.Repositories.ExpenseRepositoryTests
{
    using System.Linq;

    using DataContexts;

    using Domain.Entities;

    using Foundation.Repositories;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WhenNewExpenseSaved
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
        }

        [TestMethod]
        public void Should_add_entity_to_be_inserted()
        {
            Assert.AreEqual(1, this.DataContext.ChangeSet.GetInserts<Expense>().Count());
            Assert.IsNotNull(
                    this.DataContext.ChangeSet.GetInserts<Expense>().Where(e => e == this.Expense).FirstOrDefault());
        }
    }
}