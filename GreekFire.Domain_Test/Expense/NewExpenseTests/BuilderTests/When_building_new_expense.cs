using GreekFire.Domain;
using GreekFireExpense.Foundation_Test.Bdd;
using NUnit.Framework;

namespace GreekFire.Domain_Test
{
    [Category("NewExpense")]
    [TestFixture]
    public class When_building_new_expense : EmptyContext
    {
        private const string _description = "Approved Expense Description";
        private const string _title = "Approved Expense Title";
        private NewExpense _expense;
        private ExpenseDto _expenseDto;

        protected override void BecauseOf()
        {
            _expense = NewExpense.create()
                .withTitle(_title)
                .withDescription(_description)
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
    }
}