using GreekFireExpense.Foundation_Test.Mocks;
using NUnit.Framework;

namespace GreekFireExpense.Foundation_Test.UnitOfWorkTests
{
    [Category("UnitOfWork")]
    [TestFixture]
    public class When_get_repository_not_in_unit_of_work : UnitOfWorkWithMockRepositoryContext
    {
        private FakeRepository _repository;

        protected override void BecauseOf()
        {
            base.BecauseOf();

            _repository = UnitOfWork.GetRepository<FakeRepository>();
        }

        [Test]
        public void repository_should_be_null()
        {
            Assert.IsNull(_repository);
        }
    }
}