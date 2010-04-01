using System.Linq;
using NUnit.Framework;

namespace GreekFireExpense.Foundation_Test.ChangeSetTests
{
    [Category("ChangeSet")]
    [TestFixture]
    public class When_item_is_updated : EmptyChangeSetContext
    {
        private object Item { get; set; }

        protected override void Context()
        {
            base.Context();

            Item = new object();

            object itemBefore = ChangeSet.GetUpdates<object>().Where(i => i == Item).FirstOrDefault();

            Assert.IsNull(itemBefore);
        }

        protected override void BecauseOf()
        {
            base.BecauseOf();

            ChangeSet.AddUpdate(Item);
        }

        [Test]
        public void should_add_object_to_update_collection()
        {
            object itemAfter = ChangeSet.GetUpdates<object>().Where(i => i == Item).FirstOrDefault();

            Assert.IsNotNull(itemAfter);
            Assert.AreEqual(Item, itemAfter);
        }

        [Test]
        public void should_increase_update_count_by_one()
        {
            Assert.AreEqual(1, ChangeSet.GetUpdates<object>().Count());
        }
    }
}