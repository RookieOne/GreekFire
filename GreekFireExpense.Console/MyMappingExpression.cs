using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.Linq.Expressions;
using AutoMapper;

namespace GreekFireExpense.Console
{
    public class MyMappingExpression<D, E> : IMappingExpression<EntityCollection<D>, IEnumerable<E>>
        where D : class, IEntityWithRelationships
    {
        public void ExecutedWith(Func<EntityCollection<D>, IEnumerable<E>> mappingFunction)
        {
            throw new NotImplementedException();
        }

        public void ForAllMembers(Action<IMemberConfigurationExpression<EntityCollection<D>>> memberOptions)
        {
            throw new NotImplementedException();
        }

        public IMappingExpression<EntityCollection<D>, IEnumerable<E>> ForMember(
            Expression<Func<IEnumerable<E>, object>> destinationMember,
            Action<IMemberConfigurationExpression<EntityCollection<D>>> memberOptions)
        {
            throw new NotImplementedException();
        }

        public IMappingExpression<EntityCollection<D>, IEnumerable<E>> WithProfile(string profileName)
        {
            throw new NotImplementedException();
        }

        void IMappingExpression<EntityCollection<D>, IEnumerable<E>>.ExecutedWith(
            Func<EntityCollection<D>, IEnumerable<E>> mappingFunction)
        {
            throw new NotImplementedException();
        }

        void IMappingExpression<EntityCollection<D>, IEnumerable<E>>.ForAllMembers(
            Action<IMemberConfigurationExpression<EntityCollection<D>>> memberOptions)
        {
            throw new NotImplementedException();
        }

        IMappingExpression<EntityCollection<D>, IEnumerable<E>> IMappingExpression<EntityCollection<D>, IEnumerable<E>>.
            ForMember(Expression<Func<IEnumerable<E>, object>> destinationMember,
                      Action<IMemberConfigurationExpression<EntityCollection<D>>> memberOptions)
        {
            throw new NotImplementedException();
        }

        IMappingExpression<EntityCollection<D>, IEnumerable<E>> IMappingExpression<EntityCollection<D>, IEnumerable<E>>.
            Include<TOtherSource, TOtherDestination>()
        {
            throw new NotImplementedException();
        }

        IMappingExpression<EntityCollection<D>, IEnumerable<E>> IMappingExpression<EntityCollection<D>, IEnumerable<E>>.
            WithProfile(string profileName)
        {
            throw new NotImplementedException();
        }
    }
}