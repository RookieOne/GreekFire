using System;
using System.Linq;
using AutoMapper;
using GreekFireExpense.Data.EntityFramework.Converters;
using GreekFireExpense.Domain;

namespace GreekFireExpense.Data.EntityFramework.Mappings
{
    /// <summary>
    /// Maps Expense to an ExpenseTable
    /// </summary>
    public class EntityFrameworkMap
    {
        static EntityFrameworkMap()
        {
            var converter = new EfCollectionConverter();

            Mapper.CreateMap<ExpenseLineItem, ExpenseLineItems>();
            Mapper.CreateMap<ExpenseLineItems, ExpenseLineItem>();

            Mapper.CreateMap<Expense, Expenses>()
                .ExecutedWith(
                e =>
                    {
                        var data = new Expenses();
                        data.Description = e.Description;
                        data.Title = e.Title;

                        foreach (var item in e.LineItems)
                            data.ExpenseLineItems.Add(Mapper.Map<ExpenseLineItem, ExpenseLineItems>(item));

                        return data;
                    });

            Mapper.CreateMap<Expenses, Expense>()
                                .ExecutedWith(
                d =>
                {
                    var e = new Expense();
                    e.Description = d.Description;
                    e.Title = d.Title;

                    d.ExpenseLineItems.Load();                    
                    foreach (var item in d.ExpenseLineItems)
                        e.AddLineItem(Mapper.Map<ExpenseLineItems, ExpenseLineItem>(item));

                    return e;
                });
        }

        public object GetDataObject(object entity)
        {
            TypeMap map = Mapper.GetAllTypeMaps().FirstOrDefault(m => m.SourceType == entity.GetType());

            if (map == null) return null;

            object result = Mapper.Map(entity, map.SourceType, map.DestinationType);

            return result;
        }

        public object GetEntity(object dataObject)
        {
            TypeMap map = Mapper.GetAllTypeMaps().FirstOrDefault(m => m.SourceType == dataObject.GetType());

            if (map == null) return null;

            object result =  Mapper.Map(dataObject, map.SourceType, map.DestinationType);

            return result;
        }

        public string GetEntitySetName<T>()
        {
            TypeMap map = Mapper.GetAllTypeMaps().FirstOrDefault(m => m.SourceType == typeof (T));

            if (map == null) return null;

            return map.DestinationType.Name;
        }
    }
}