using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using GreekFireExpense.Data.EntityFramework.ExpressionVisitors;
using GreekFireExpense.Data.EntityFramework.Mappings;
using GreekFireExpense.Foundation.Repository;

namespace GreekFireExpense.Data.EntityFramework.RepositoryStrategies
{
    public class EntityFrameworkRepositoryStrategy : IRepositoryStrategy
    {
        private GreekFireExpenseDBEntities Database { get; set; }
        private EntityFrameworkMap Map { get; set; }

        public EntityFrameworkRepositoryStrategy()
        {
            Database = new GreekFireExpenseDBEntities();
            Map = new EntityFrameworkMap();
        }

        public T GetById<T>(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll<T>()
        {
            string entitySetName = Map.GetEntitySetName<T>();
            
            var table = Database.GetType().GetProperty(entitySetName).GetValue(Database, null) as ObjectQuery;
            
            var result = new List<T>();

            foreach(var dataObject in table)
            {
                result.Add((T)Map.GetEntity(dataObject));
            }

            return result.AsQueryable<T>();
        }

        public void Save<T>(T entity)
        {
            object dataObject = Map.GetDataObject(entity);
            string entitySetName = Map.GetEntitySetName<T>();

            EntityKey key = Database.CreateEntityKey(entitySetName, dataObject);
            object found;

            if (Database.TryGetObjectByKey(key, out found))
            {
                Database.ApplyPropertyChanges(entitySetName, dataObject);
            }
            else
            {
                Database.AddObject(entitySetName, dataObject);
            }
        }

        public void Delete<T>(T entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            Database.SaveChanges();
        }

        public IQueryable<T> Query<T>(Expression expression)
        {
            var modifier = new DataMapVisitor(Database);
            var executed = modifier.Execute(expression);

            var result = new List<T>();
            foreach (var dataObject in executed)
            {
                result.Add((T)Map.GetEntity(dataObject));
            }

            return result.AsQueryable<T>();
        }

    }
}