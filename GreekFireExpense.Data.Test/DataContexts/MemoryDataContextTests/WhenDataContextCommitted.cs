using System.Linq;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Data.Test.DataContexts.MemoryDataContextTests
{
    [TestClass]
    public class WhenDataContextCommitted
    {
        #region Properties

        private MemoryDataContext DataContext { get; set; }

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            DataContext = new MemoryDataContext();
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Should_reset_changeset()
        {
            DataContext.Save(new object());        

            Assert.AreEqual(1, DataContext.ChangeSet.GetInserts<object>().Count());
            DataContext.Commit();

            Assert.AreEqual(0, DataContext.ChangeSet.GetInserts<object>().Count());
        }

        [TestMethod]
        public void Should_raise_completed_event()
        {
            bool eventRaised = false;

            DataContext.Completed += (sender, e) => eventRaised = true;
            DataContext.Commit();

            Assert.IsTrue(eventRaised);
        }

        #endregion
    }
}
