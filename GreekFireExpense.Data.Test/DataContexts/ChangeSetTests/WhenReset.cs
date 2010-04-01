using System.Linq;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Data.Test.DataContexts.ChangeSetTests
{
    [TestClass]
    public class WhenReset
    {
        #region Properties

        ChangeSet ChangeSet { get; set; }

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            ChangeSet = new ChangeSet();
            ChangeSet.AddInsert(new object());
            ChangeSet.AddUpdate(new object());
            ChangeSet.AddDelete(new object());
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Should_reduce_insert_count_to_zero()
        {
            Assert.AreEqual(1, ChangeSet.GetInserts<object>().Count());

            ChangeSet.Reset();

            Assert.AreEqual(0, ChangeSet.GetInserts<object>().Count());
        }

        [TestMethod]
        public void Should_reduce_update_count_to_zero()
        {
            Assert.AreEqual(1, ChangeSet.GetUpdates<object>().Count());

            ChangeSet.Reset();

            Assert.AreEqual(0, ChangeSet.GetUpdates<object>().Count());
        }

        [TestMethod]
        public void Should_reduce_delete_count_to_zero()
        {
            Assert.AreEqual(1, ChangeSet.GetDeletes<object>().Count());

            ChangeSet.Reset();

            Assert.AreEqual(0, ChangeSet.GetDeletes<object>().Count());
        }

        #endregion
    }
}
