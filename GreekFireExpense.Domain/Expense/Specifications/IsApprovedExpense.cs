using System.Linq;
using GreekFire.Foundation.Specifications;

namespace GreekFire.Domain
{
    public class IsApprovedExpense : Specification<ExpenseDto>
    {
        public static IsApprovedExpense Create()
        {
            return new IsApprovedExpense();    
        }

        public override IQueryable<ExpenseDto> SatisfyingElementsFrom(IQueryable<ExpenseDto> candidates)
        {
            return candidates.Where(e => e.ApprovalDate != null);
        }
    }
}