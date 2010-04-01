using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Text;
using AutoMapper;

namespace GreekFireExpense.Data.EntityFramework.Converters
{
    public class EfCollectionConverter 
    {
        public EntityCollection<D> ConvertToEf<D, E>(IEnumerable<E> enumerable) where D: class, IEntityWithRelationships
        {
            var result = new EntityCollection<D>();

            foreach(E entity in enumerable)
            {
                var data = Mapper.Map<E, D>(entity);
                result.Add(data);
            }

            return result;
        }
    }
}
