using GreekFireExpense.Foundation_Test.Mocks;
using NUnit.Framework;

namespace GreekFireExpense.Foundation_Test.UnitOfWorkTests
{
    [Category("UnitOfWork")]
    [TestFixture]
    public class When_get_repository_in_unit_of_work : UnitOfWorkWithMockRepositoryContext
    {
        private MockRepository _repository;

        protected override void BecauseOf()
        {
            base.BecauseOf();

            _repository = UnitOfWork.GetRepository<MockRepository>();
        }

        [Test]
        public void respository_should_not_be_null()
        {
            Assert.IsNotNull(_repository);
        }
    }
}