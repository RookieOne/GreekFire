using GreekFire.Foundation.UnitOfWorks;
using GreekFireExpense.Foundation_Test.Bdd;
using GreekFireExpense.Foundation_Test.Mocks;
using Microsoft.Practices.Unity;

namespace GreekFireExpense.Foundation_Test.UnitOfWorkTests
{
    public abstract class UnitOfWorkWithMockRepositoryContext : ContextSpecification
    {
        protected UnitOfWork UnitOfWork { get; set; }

        protected override void Context()
        {
            IUnityContainer container = UnitOfWork.GetRepositoryContainer();
            container.RegisterType<MockRepository, MockRepository>();

            UnitOfWork = new UnitOfWork();
        }
    }
}