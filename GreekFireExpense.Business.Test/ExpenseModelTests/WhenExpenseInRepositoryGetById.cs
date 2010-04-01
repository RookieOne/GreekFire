using GreekFireExpense.Data.DataContexts;
using GreekFireExpense.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Business.Test.ExpenseModelTests
{
    [TestClass]
    public class WhenExpenseInRepositoryGetById
    {
        #region Properties

        public ExpenseModel ExpenseModel { get; set; }
        public Expense Expense { get; set; }
        public int Id { get; set; }

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            Id = 1;

            Expense = new Expense
                          {
                              Id = Id                              
                          };

            var dataContext = new MemoryDataContext();
            dataContext.Save(Expense);
            dataContext.Commit();

            ExpenseModel = new ExpenseModel(dataContext);
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Should_not_return_null()
        {
            Assert.IsNotNull(ExpenseModel.GetById(Id));
        }

        [TestMethod]
        public void Should_return_expense()
        {
            var expense = ExpenseModel.GetById(Id);
            Assert.AreEqual(expense, Expense);
        }

        #endregion
    }
}
