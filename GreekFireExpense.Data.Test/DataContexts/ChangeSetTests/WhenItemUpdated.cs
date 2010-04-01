using System.Linq;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Data.Test.DataContexts.ChangeSetTests
{
    [TestClass]
    public class WhenItemUpdated
    {
        #region Properties

        ChangeSet ChangeSet { get; set; }
        object Item { get; set; }

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            ChangeSet = new ChangeSet();
            Item = new object();
        }

        #endregion


        #region Tests

        [TestMethod]
        public void Should_increase_update_count_by_one()
        {
            Assert.AreEqual(0, ChangeSet.GetUpdates<object>().Count());

            ChangeSet.AddUpdate(Item);

            Assert.AreEqual(1, ChangeSet.GetUpdates<object>().Count());
        }

        [TestMethod]
        public void Should_add_object_to_update_collection()
        {
            var itemBefore = ChangeSet.GetUpdates<object>()
                                    .Where(i => i == Item)
                                    .FirstOrDefault();

            Assert.IsNull(itemBefore);

            ChangeSet.AddUpdate(Item);

            var itemAfter = ChangeSet.GetUpdates<object>()
                                    .Where(i => i == Item)
                                    .FirstOrDefault();

            Assert.IsNotNull(itemAfter);
            Assert.AreEqual(Item, itemAfter);
        }

        #endregion
    }
}
