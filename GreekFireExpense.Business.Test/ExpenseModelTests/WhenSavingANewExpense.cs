using System.Linq;
using GreekFireExpense.Domain;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Business.Test.ExpenseModelTests
{
    [TestClass]
    public class WhenSavingANewExpense
    {
        #region Properties

        public ExpenseModel ExpenseModel { get; set; }
        public IDataContext DataContext { get; set; }
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
                Id = Id,
                Amount = 500,
                Description = "Test"
            };

            DataContext = new MemoryDataContext();

            ExpenseModel = new ExpenseModel(DataContext);                       
        }

        #endregion


        #region Tests

        [TestMethod]
        public void Should_increase_insert_count()
        {
            Assert.AreEqual(0, DataContext.ChangeSet.GetInserts<Expense>().Count());            

            ExpenseModel.Save(Expense); 

            Assert.AreEqual(1, DataContext.ChangeSet.GetInserts<Expense>().Count());            
        }

        [TestMethod]
        public void Should_insert_expense()
        {
            var expenseBefore = DataContext.ChangeSet.GetInserts<Expense>().FirstOrDefault();

            Assert.IsNull(expenseBefore);

            ExpenseModel.Save(Expense); 

            var expenseAfter = DataContext.ChangeSet.GetInserts<Expense>().FirstOrDefault();

            Assert.AreEqual(Expense, expenseAfter);
        }

        #endregion
    }
}
