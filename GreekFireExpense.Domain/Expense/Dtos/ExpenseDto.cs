using System;
using System.Collections.Generic;

namespace GreekFire.Domain
{
    /// <summary>
    /// Expense Data Transfer Object
    /// </summary>
    [Serializable]
    public class ExpenseDto
    {
        public virtual DateTime? ApprovalDate { get; internal set; }
        public virtual DateTime CreatedDate { get; internal set; }
        public virtual string Description { get; set; }
        public virtual int Id { get; set; }
        public virtual IList<ExpenseLineItemDto> LineItems { get; set; }
        public virtual string Title { get; set; }
        public decimal Total { get; set; }
    }
}