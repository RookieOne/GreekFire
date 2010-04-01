using System;

namespace GreekFire.Domain
{
    public partial class NewExpense : Expense
    {
        public ApprovedExpense Approve(DateTime approvalDate)
        {
            return ApprovedExpense.create()
                .copy(this)
                .approvedOn(approvalDate)
                .complete();
        }
    }
}