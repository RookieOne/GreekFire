using GreekFire.Data.NHibernate.RepositoryStrategies;
using GreekFire.Domain;
using GreekFire.Foundation.RepositoryStrategies;
using GreekFire.Foundation.UnitOfWorks;
using Microsoft.Practices.Unity;

namespace GreekFire.Services
{
    public static class UnitOfWorkConfig
    {
        private static bool _configured;

        public static void Build()
        {
            if (!_configured)
            {
                IUnityContainer repositoryContainer = UnitOfWork.GetRepositoryContainer();

                repositoryContainer.RegisterType<ExpenseRepository, ExpenseRepository>();

                var lifetimeManager = new ContainerControlledLifetimeManager();
                repositoryContainer.RegisterType<IRepositoryStrategy, NHibernateRepositoryStrategy>("ExpenseDatabase",
                                                                                                    lifetimeManager);

                _configured = true;
            }
        }
    }
}