using System.Linq;
using GreekFireExpense.Data.DataContexts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFireExpense.Data.Test.DataContexts.MemoryDataContextTests
{
    [TestClass]
    public class WhenObjectInserted
    {
        #region Properties

        private MemoryDataContext DataContext { get; set; }
        private object ObjectToInsert { get; set; }

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            DataContext = new MemoryDataContext();

            ObjectToInsert = new object();

            DataContext.Save(ObjectToInsert);
        }

        #endregion

        #region Tests

        [TestMethod]
        public void Should_be_able_to_get_object_in_repository()
        {
            var objectFound = (from o in DataContext.Repository<object>()
                               where o == ObjectToInsert
                               select o).FirstOrDefault();

            Assert.IsNotNull(objectFound);
            Assert.AreEqual(objectFound, ObjectToInsert);
        }

        [TestMethod]
        public void Should_update_changset_inserted_objects()
        {
            var objectFound = (from o in DataContext.ChangeSet.GetInserts<object>()
                               where o == ObjectToInsert
                               select o).FirstOrDefault();

            Assert.IsNotNull(objectFound);
            Assert.AreEqual(ObjectToInsert, objectFound);
        }

        [TestMethod]
        public void Should_update_changset_inserted_objects_count()
        {
            Assert.AreEqual(1, DataContext.ChangeSet.GetInserts<object>().Count());            
        }

        #endregion
    }
}