using GreekFire.Domain;
using NUnit.Framework;

namespace GreekFire.Domain_Test
{
    [Category("NewExpense")]
    [TestFixture]
    public class When_adding_lineItem_to_new_expense : NewExpenseContext
    {
        private ExpenseDto _expenseDto;
        private ExpenseLineItemDto _expenseLineItemDto;
        private ExpenseLineItem _lineItemToAdd;

        protected override void BecauseOf()
        {
            base.BecauseOf();

            _lineItemToAdd = ExpenseLineItem.create()
                .complete();

            Expense.AddLineItem(_lineItemToAdd);

            _expenseDto = Expense.ToDto();
            _expenseLineItemDto = _lineItemToAdd.ToDto(_expenseDto);
        }

        [Test]
        public void Should_add_line_item_to_expense()
        {
            Assert.IsTrue(_expenseDto.LineItems.Contains(_expenseLineItemDto));
        }
    }
}