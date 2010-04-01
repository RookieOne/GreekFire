using System;

namespace GreekFire.Domain
{
    /// <summary>
    /// Partial class for Approved Expense that contains the builder
    /// </summary>
    public partial class ApprovedExpense
    {
        /// <summary>
        /// Creates the builder to use for building an approved expense.
        /// </summary>
        /// <returns></returns>
        public static ApprovedExpenseBuilder create()
        {
            return new ApprovedExpenseBuilder();
        }

        public override ExpenseDto ToDto()
        {
            var dto = base.ToDto();
            dto.ApprovalDate = ApprovalDate;

            return dto;
        }

        /// <summary>
        /// Builder for ApprovedExpense
        /// </summary>
        public class ApprovedExpenseBuilder : Builder<ApprovedExpense, ApprovedExpenseBuilder>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ApprovedExpenseBuilder"/> class.
            /// </summary>
            public ApprovedExpenseBuilder()
            {
                _expense = new ApprovedExpense();
            }

            /// <summary>
            /// Sets the approval date
            /// </summary>
            /// <param name="date">The date.</param>
            /// <returns></returns>
            public ApprovedExpenseBuilder approvedOn(DateTime date)
            {
                _expense.ApprovalDate = date;
                return this;
            }

            /// <summary>
            /// Populates Approved Expense from the dto.
            /// </summary>
            /// <param name="dto">The dto.</param>
            /// <returns></returns>
            public override ApprovedExpenseBuilder fromDto(ExpenseDto dto)
            {
                base.fromDto(dto);

                if (dto.ApprovalDate != null)
                    approvedOn((DateTime) dto.ApprovalDate);

                return this;
            }
        }
    }
}