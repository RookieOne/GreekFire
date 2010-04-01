using System.Linq;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Data.Test.DataContexts.MemoryDataContextTests
{
    [TestClass]
    public class WhenObjectDeleted
    {
        #region Properties

        private MemoryDataContext DataContext { get; set; }
        private object ObjectToDelete { get; set; }

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            DataContext = new MemoryDataContext();

            ObjectToDelete = new object();

            DataContext.Save(ObjectToDelete);
            DataContext.Commit();

            DataContext.Delete(ObjectToDelete);
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Should_not_be_able_to_get_object_in_repository()
        {
            var objectFound = (from o in DataContext.Repository<object>()
                               where o == ObjectToDelete
                               select o).FirstOrDefault();

            Assert.IsNull(objectFound);
        }

        [TestMethod]
        public void Should_update_changset_deleted_objects()
        {
            var objectFound = (from o in DataContext.ChangeSet.GetDeletes<object>()
                               where o == ObjectToDelete
                               select o).FirstOrDefault();

            Assert.IsNotNull(objectFound);
            Assert.AreEqual(ObjectToDelete, objectFound);
        }

        [TestMethod]
        public void Should_update_changset_deleted_objects_count()
        {
            Assert.AreEqual(1, DataContext.ChangeSet.GetDeletes<object>().Count());
        }

        #endregion
    }
}