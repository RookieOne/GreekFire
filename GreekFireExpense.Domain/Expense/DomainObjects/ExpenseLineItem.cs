namespace GreekFire.Domain
{
    /// <summary>
    /// An expense line item is a line item in a expense.
    /// </summary>
    public partial class ExpenseLineItem
    {
        private decimal Amount { get; set; }
        private string Description { get; set; }
        private int Id { get; set; }

        public decimal GetAmount()
        {
            return Amount;
        }
    }
}