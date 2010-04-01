using System;
using System.Collections.Generic;
using System.Linq;
using GreekFire.Foundation.Specifications;

namespace GreekFire.Domain
{
    /// <summary>
    /// An expense has line items that can be added
    /// </summary>
    public abstract partial class Expense : IHasIntId
    {
        protected string Description { get; set; }
        public int Id { get; protected set; }
        protected IList<ExpenseLineItem> LineItems { get; set; }
        protected string Title { get; set; }
        protected DateTime CreatedDate { get; set; }

        /// <summary>
        /// Adds a line item to this expense.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public Expense AddLineItem(ExpenseLineItem item)
        {
            LineItems.Add(item);
            return this;
        }

        public decimal CalculateTotal()
        {
            return LineItems.Sum(i => i.GetAmount());
        }
    }
}