using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Business.Test.ExpenseModelTests
{
    [TestClass]
    public class WhenExpenseNotInRepositoryGetById
    {
        #region Properties

        public ExpenseModel ExpenseModel { get; set; }
        public int Id { get; set; }

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            Id = 1;

            var dataContext = new MemoryDataContext();

            ExpenseModel = new ExpenseModel(dataContext);
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Should_return_null()
        {
            Assert.IsNull(ExpenseModel.GetById(Id));
        }

        #endregion
    }
}
