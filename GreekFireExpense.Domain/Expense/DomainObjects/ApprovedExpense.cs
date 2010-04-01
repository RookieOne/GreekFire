using System;

namespace GreekFire.Domain
{
    /// <summary>
    /// An approved expense is an expense that has gone through the approval process
    /// </summary>
    public partial class ApprovedExpense : Expense
    {
        /// <summary>
        /// The Approval Date is the date the expense was approved
        /// </summary>
        /// <value>The approval date.</value>
        private DateTime ApprovalDate { get; set; }
    }
}