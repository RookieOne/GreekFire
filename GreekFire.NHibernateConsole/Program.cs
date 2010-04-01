using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GreekFire.Data.NHibernate.RepositoryStrategies;
using GreekFire.Domain;
using GreekFire.Foundation.RepositoryStrategies;
using GreekFire.Foundation.UnitOfWorks;
using GreekFire.NHibernateConsole.GreekFireServices;
using Microsoft.Practices.Unity;

namespace GreekFire.NHibernateConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TestConnection();

            var service =  new ExpenseFacadeClient();

            var expenses = service.GetExpenses();

            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        private static void TestConnection()
        {
            var config = MsSqlConfiguration.MsSql2005
.ConnectionString(c => c.Server(@"LUBU\SQLExpress2")
.Database("GreekFireExpenseDB")
.TrustedConnection());


            var factory = Fluently.Configure()
                .Database(config)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepositoryStrategy>())
                .BuildSessionFactory();

            using(var session = factory.OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    
                }
            }            
        }

        private static void ConfigureContainerAndUowNhibernate()
        {
            IUnityContainer repositoryContainer = UnitOfWork.GetRepositoryContainer();

            repositoryContainer.RegisterType<ExpenseRepository, ExpenseRepository>();

            var lifetimeManager = new ContainerControlledLifetimeManager();
            repositoryContainer.RegisterType<IRepositoryStrategy, NHibernateRepositoryStrategy>("ExpenseDatabase",
                                                                                                lifetimeManager);
        }
    }
}