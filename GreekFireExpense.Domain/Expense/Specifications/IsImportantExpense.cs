using System.Linq;
using GreekFire.Foundation.Specifications;

namespace GreekFire.Domain
{
    public class IsImportantExpense : Specification<ExpenseDto>
    {
        public static IsImportantExpense Create()
        {
            return new IsImportantExpense();
        }

        public override IQueryable<ExpenseDto> SatisfyingElementsFrom(IQueryable<ExpenseDto> candidates)
        {
            return candidates.Where(e => e.Total > 1000);
        }
    }
}