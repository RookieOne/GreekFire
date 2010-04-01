using FluentNHibernate.Mapping;
using GreekFire.Domain;

namespace GreekFire.Data.NHibernate.ExpenseMappings
{
    public class ExpenseMap : ClassMap<ExpenseDto>
    {
        public ExpenseMap()            
        {
            WithTable("GreekFireExpense.Expenses");

            Id(e => e.Id);
            Map(e => e.Title);
            Map(e => e.Description);
            HasMany(e => e.LineItems)
                .WithKeyColumn("Expense")
                .Inverse()
                .AsList();
        }
    }
}
