namespace GreekFire.Domain
{
    /// <summary>
    /// Partial Class for ExpenseLineItem
    /// And contains the private constructor
    /// And the ToDto method
    /// </summary>
    public partial class ExpenseLineItem
    {
        /// <summary>
        /// Turns the ExpenseLineItem into the appropriate Data Transfer Object
        /// </summary>
        /// <param name="expenseDto">The expense dto to maintain the 1 to many relation.</param>
        /// <returns>ExpenseLineItemDto</returns>
        public ExpenseLineItemDto ToDto(ExpenseDto expenseDto)
        {
            return new ExpenseLineItemDto
            {
                Id = Id,
                Amount = Amount,
                Description = Description,
                Expense = expenseDto
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseLineItem"/> class.
        /// Private constructor to prevent construction of an ExpenseLineItem without using
        /// the Builder
        /// </summary>
        private ExpenseLineItem()
        {
        }

        /// <summary>
        /// Creates a builder used to build an ExpenseLineItem.
        /// </summary>
        /// <returns></returns>
        public static ExpenseLineBuilder create()
        {
            return new ExpenseLineBuilder();
        }

        /// <summary>
        /// ExpenseLineBuilder controls the construction of an ExpenseLineItem
        /// using a fluent interface
        /// </summary>
        public class ExpenseLineBuilder
        {
            private ExpenseLineItem _item;

            public ExpenseLineBuilder()
            {
                _item = new ExpenseLineItem();
            }

            /// <summary>
            /// Sets the amount.
            /// </summary>
            /// <param name="amount">The amount.</param>
            /// <returns></returns>
            public ExpenseLineBuilder withAmount(decimal amount)
            {
                _item.Amount = amount;
                return this;
            }

            /// <summary>
            /// Sets the description.
            /// </summary>
            /// <param name="description">The description.</param>
            /// <returns></returns>
            public ExpenseLineBuilder withDescription(string description)
            {
                _item.Description = description;
                return this;
            }

            /// <summary>
            /// Populates the ExpenseLineItem from dto.
            /// </summary>
            /// <param name="dto">The dto.</param>
            /// <returns></returns>
            public ExpenseLineBuilder fromDto(ExpenseLineItemDto dto)
            {                
                _item.Id = dto.Id;
                _item.Description = dto.Description;
                _item.Amount = dto.Amount;

                return this;
            }

            /// <summary>
            /// Builds and returns the ExpenseLineItem.
            /// </summary>
            /// <returns></returns>
            public ExpenseLineItem complete()
            {
                return _item;
            }
        }
    }
}
