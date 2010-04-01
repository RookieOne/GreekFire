namespace GreekFire.Domain
{
    public partial class NewExpense
    {
        /// <summary>
        /// Creates the builder to use for building a new expense.
        /// </summary>
        /// <returns></returns>
        public static NewExpenseBuilder create()
        {
            return new NewExpenseBuilder();
        }

        public class NewExpenseBuilder : Builder<NewExpense, NewExpenseBuilder>
        {
            public NewExpenseBuilder()
            {
                _expense = new NewExpense();
            }
        }
    }
}