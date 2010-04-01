using System.Linq;
using GreekFireExpense.Data.DataContexts;
using GreekFireExpense.Domain;

namespace GreekFireExpense.Business
{
    /// <summary>
    /// Expense Model is the Business Model for Expense.
    /// GetsById and Saves Expense into the DataContext.
    /// </summary>
    public class ExpenseModel
    {
        #region Properties

        private IDataContext DataContext { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseModel"/> class
        /// using the passed in DataContext as a Unit of Work
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public ExpenseModel(IDataContext dataContext)
        {
            DataContext = dataContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Gets the expense by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns></returns>
        public Expense GetById(int id)
        {
            return DataContext.Repository<Expense>()
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }

        /// <summary>
        /// Saves the expense either inserting or updating the datacontext
        /// </summary>
        /// <param name="expense">The expense.</param>
        public void Save(Expense expense)
        {
            DataContext.Save(expense);
        }

        #endregion
    }
}