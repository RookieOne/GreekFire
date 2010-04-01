using System.Linq;
using NUnit.Framework;

namespace GreekFireExpense.Foundation_Test.ChangeSetTests
{
    [Category("ChangeSet")]
    [TestFixture]
    public class When_reset : EmptyChangeSetContext
    {
        protected override void Context()
        {
            base.Context();

            ChangeSet.AddInsert(new object());
            ChangeSet.AddUpdate(new object());
            ChangeSet.AddDelete(new object());

            Assert.AreEqual(1, ChangeSet.GetDeletes<object>().Count());
            Assert.AreEqual(1, ChangeSet.GetInserts<object>().Count());
            Assert.AreEqual(1, ChangeSet.GetUpdates<object>().Count());
        }

        protected override void BecauseOf()
        {
            base.BecauseOf();

            ChangeSet.Reset();
        }

        [Test]
        public void Should_reduce_delete_count_to_zero()
        {
            Assert.AreEqual(0, ChangeSet.GetDeletes<object>().Count());
        }

        [Test]
        public void Should_reduce_insert_count_to_zero()
        {
            Assert.AreEqual(0, ChangeSet.GetInserts<object>().Count());
        }

        [Test]
        public void Should_reduce_update_count_to_zero()
        {
            Assert.AreEqual(0, ChangeSet.GetUpdates<object>().Count());
        }
    }
}