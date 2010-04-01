using System;
using System.Linq;
using System.Linq.Expressions;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using GreekFire.Foundation.RepositoryStrategies;
using GreekFire.Foundation.Specifications;
using NHibernate;
using NHibernate.Linq;

namespace GreekFire.Data.NHibernate.RepositoryStrategies
{
    public class NHibernateRepositoryStrategy : IRepositoryStrategy
    {
        private readonly ISession _session;
        private readonly ITransaction _transaction;

        public NHibernateRepositoryStrategy(INHibernateConfig config)
        {
            //@"LUBU\SQLExpress2"
            //"GreekFireExpenseDB"
            MsSqlConfiguration sqlConfig = MsSqlConfiguration.MsSql2005
                .ConnectionString(c => c.Server(config.Server)
                                           .Database(config.DatabaseName)
                                           .TrustedConnection());

            ISessionFactory factory = Fluently.Configure()
                .Database(sqlConfig)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<NHibernateRepositoryStrategy>())
                .BuildSessionFactory();

            _session = factory.OpenSession();

            _transaction = _session.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll<T>()
        {
            return from entity in _session.Linq<T>()
                   select entity;
        }

        public T GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public void Save<T>(T entity)
        {
            _session.SaveOrUpdate(entity);
        }

        public void Dispose()
        {
            _session.Dispose();
            _transaction.Dispose();
        }

        public IQueryable<T> Where<T>(ISpecification<T> spec)
        {
            return spec.SatisfyingElementsFrom(_session.Linq<T>());
        }
    }
}