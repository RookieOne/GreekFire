
using System.Linq;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Data.Test.DataContexts.ChangeSetTests
{
    [TestClass]
    public class WhenItemInserted
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
        public void Should_increase_insert_count_by_one()
        {
            Assert.AreEqual(0, ChangeSet.GetInserts<object>().Count());

            ChangeSet.AddInsert(Item);

            Assert.AreEqual(1, ChangeSet.GetInserts<object>().Count());
        }

        [TestMethod]
        public void Should_add_object_to_insert_collection()
        {
            var itemBefore = ChangeSet.GetInserts<object>()
                                    .Where(i => i == Item)
                                    .FirstOrDefault();

            Assert.IsNull(itemBefore);

            ChangeSet.AddInsert(Item);

            var itemAfter = ChangeSet.GetInserts<object>()
                                    .Where(i => i == Item)
                                    .FirstOrDefault();

            Assert.IsNotNull(itemAfter);
            Assert.AreEqual(Item, itemAfter);
        }

        #endregion
    }
}
