using GreekFire.Domain;
using GreekFireExpense.Foundation_Test.Bdd;

namespace GreekFire.Domain_Test
{
    public abstract class NewExpenseContext : ContextSpecification
    {
        protected NewExpense Expense { get; set; }

        protected override void Context()
        {
            Expense = NewExpense.create().complete();
        }
    }
}