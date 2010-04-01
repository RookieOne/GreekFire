using System;
using GreekFire.Domain;
using GreekFireExpense.Foundation_Test.Bdd;
using NUnit.Framework;

namespace GreekFire.Domain_Test
{
    [Category("ApprovedExpense")]
    [TestFixture]
    public class When_building_approved_expense : EmptyContext
    {
        private const string _description = "Approved Expense Description";
        private const string _title = "Approved Expense Title";
        private readonly DateTime _approvalDate = new DateTime(2001, 9, 11);
        private ApprovedExpense _expense;
        private ExpenseDto _expenseDto;

        protected override void BecauseOf()
        {
            _expense = ApprovedExpense.create()
                .withTitle(_title)
                .withDescription(_description)
                .approvedOn(_approvalDate)
                .complete();

            _expenseDto = _expense.ToDto();
        }

        [Test]
        public void should_set_title()
        {
            Assert.AreEqual(_title, _expenseDto.Title);
        }

        [Test]
        public void should_set_description()
        {
            Assert.AreEqual(_description, _expenseDto.Description);
        }

        [Test]
        public void should_set_approval_date()
        {
            Assert.AreEqual(_approvalDate, _expenseDto.ApprovalDate);
        }
    }
}