using System;

namespace GreekFire.Domain
{
    /// <summary>
    /// Expense Line Item Data Transfer Object
    /// </summary>
    [Serializable]
    public class ExpenseLineItemDto
    {
        public virtual decimal Amount { get; set; }
        public virtual string Description { get; set; }
        public virtual ExpenseDto Expense { get; set; }
        public virtual int Id { get; set; }

        public override bool Equals(object obj)
        {
            var other = obj as ExpenseLineItemDto;

            if (other == null)
                return false;

            return Id == other.Id;
        }
    }
}
