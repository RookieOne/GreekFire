using FluentNHibernate.Mapping;
using GreekFire.Domain;

namespace GreekFire.Data.NHibernate.ExpenseMappings
{
    public class ExpenseLineItemMap: ClassMap<ExpenseLineItemDto>
    {
        public ExpenseLineItemMap()            
        {
            WithTable("GreekFireExpense.ExpenseLineItems");

            Id(i => i.Id);
            Map(i => i.Amount);
            Map(i => i.Description);
            References(i => i.Expense)
                .WithColumns("Expense");
        }
    }
}
