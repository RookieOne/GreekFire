namespace GreekFire.Domain
{
    /// <summary>
    /// The Expense Favotry is used by service
    /// </summary>
    public class ExpenseFactory
    {
        public T createFromDto<T>(ExpenseDto dto) where T : Expense
        {
            if (dto.ApprovalDate != null)
                return ApprovedExpense.create()
                                      .fromDto(dto)
                                      .complete() as T;

            return NewExpense.create()
                             .fromDto(dto)
                             .complete() as T;
        }
    }
}