using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GreekFire.Domain;
using GreekFire.Foundation.UnitOfWorks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreekFire.Data.NHibernate_Test
{
    [TestClass]
    public class When_saving_a_new_expense : NewExpenseRepositoryContext
    {
        private Expense _newExpense;

        protected override void BecauseOf()
        {
            _newExpense = NewExpense.create()
                .withTitle("New Expense")
                .withDescription("New Description")
                .complete();

            using (var uow = new UnitOfWork())
            {
                uow.GetRepository<ExpenseRepository>().Save(_newExpense);
                uow.Commit();
            }
        }

        [TestMethod]
        public void should_set_id_on_expense()
        {
            
        }
    }
}
