using System.Linq;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Data.Test.DataContexts.ChangeSetTests
{
    [TestClass]
    public class WhenItemDeleted
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
        public void Should_increase_delete_count_by_one()
        {
            Assert.AreEqual(0, ChangeSet.GetDeletes<object>().Count());

            ChangeSet.AddDelete(Item);

            Assert.AreEqual(1, ChangeSet.GetDeletes<object>().Count());
        }

        [TestMethod]
        public void Should_add_object_to_delete_collection()
        {
            var itemBefore = ChangeSet.GetDeletes<object>()
                                    .Where(i => i == Item)
                                    .FirstOrDefault();

            Assert.IsNull(itemBefore);

            ChangeSet.AddDelete(Item);

            var itemAfter = ChangeSet.GetDeletes<object>()
                                    .Where(i => i == Item)
                                    .FirstOrDefault();

            Assert.IsNotNull(itemAfter);
            Assert.AreEqual(Item, itemAfter);
        }

        #endregion
    }
}
