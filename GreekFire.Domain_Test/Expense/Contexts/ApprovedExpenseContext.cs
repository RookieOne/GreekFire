using System;
using GreekFire.Domain;
using GreekFireExpense.Foundation_Test.Bdd;

namespace GreekFire.Domain_Test
{
    public abstract class ApprovedExpenseContext : ContextSpecification
    {
        protected ApprovedExpense _expense;

        protected override void Context()
        {
            _expense = ApprovedExpense.create()
                .withTitle("Title")
                .withDescription("Description")
                .approvedOn(new DateTime(1981, 12, 8))
                .complete();
        }
    }
}