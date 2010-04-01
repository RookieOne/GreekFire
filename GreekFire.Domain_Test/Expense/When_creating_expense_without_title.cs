using GreekFire.Domain;
using GreekFire.Foundation.ValidationRules;
using GreekFireExpense.Foundation_Test.Bdd;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFire.Domain_Test
{
    [TestClass]
    public class When_creating_expense_without_title : EmptyContext
    {
        private Expense.Builder _builder;

        protected override void Context()
        {
            _builder = Expense.create();
        }

        [TestMethod]
        [ExpectedException(typeof (ValidationException))]
        public void should_throw_exception_on_build()
        {
            _builder.Build();
        }
    }
}