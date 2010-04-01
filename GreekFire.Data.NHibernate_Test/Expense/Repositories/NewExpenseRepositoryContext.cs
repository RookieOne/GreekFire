using GreekFire.Data.NHibernate.RepositoryStrategies;
using GreekFire.Domain;
using GreekFire.Foundation.RepositoryStrategies;
using GreekFire.Foundation.UnitOfWorks;
using GreekFireExpense.Foundation_Test.Bdd;
using Microsoft.Practices.Unity;

namespace GreekFire.Data.NHibernate_Test
{
    public abstract class NewExpenseRepositoryContext : ContextSpecification
    {
        protected override void Context()
        {
            IUnityContainer repositoryContainer = UnitOfWork.GetRepositoryContainer();
            
            repositoryContainer.RegisterInstance<INHibernateConfig>(NHibernateConfig.Create()
                                                                        .ServerIs(@"LUBU\SQLExpress2")
                                                                        .DatabaseNameIs("GreekFireExpenseTestDB"));

            repositoryContainer.RegisterType<ExpenseRepository, ExpenseRepository>();

            var lifetimeManager = new ContainerControlledLifetimeManager();
            repositoryContainer.RegisterType<IRepositoryStrategy, NHibernateRepositoryStrategy>("ExpenseDatabase",
                                                                                                lifetimeManager);            
        }        
    }
}