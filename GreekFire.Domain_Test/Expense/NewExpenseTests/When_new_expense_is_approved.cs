using System;
using GreekFire.Domain;
using NUnit.Framework;

namespace GreekFire.Domain_Test
{
    [Category("NewExpense")]
    [TestFixture]
    public class When_new_expense_is_approved : NewExpenseContext
    {
        private readonly DateTime _approvalDate = new DateTime(1984, 9, 24);
        private ApprovedExpense _approvedExpense;
        private ExpenseDto _expenseDto;

        protected override void BecauseOf()
        {
            base.BecauseOf();

            _approvedExpense = Expense.Approve(_approvalDate);
            _expenseDto = _approvedExpense.ToDto();
        }

        [Test]
        public void approved_expense_should_not_be_null()
        {
            Assert.IsNotNull(_approvedExpense);
        }

        [Test]
        public void should_set_approval_date()
        {
            Assert.AreEqual(_approvalDate, _expenseDto.ApprovalDate);
        }
    }
}