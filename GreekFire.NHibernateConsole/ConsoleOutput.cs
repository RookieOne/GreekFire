using System;
using GreekFire.Domain;
using GreekFire.Foundation.Extensions;
using GreekFire.Foundation.UnitOfWorks;

namespace GreekFire.NHibernateConsole
{
    public static class ConsoleOutput
    {
        public static void OutputExpenseRepository()
        {
            Console.WriteLine("In Expense Repository ...");

            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository<ExpenseRepository>();

                repository.GetExpenses()
                    .ForEach(e => OutputExpense(e));
            }

            Console.WriteLine("....");
            Console.ReadLine();
        }

        public static void OutputExpense(ExpenseDto expenseDto)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine("Expense {0} : {1}", expenseDto.Id, expenseDto.Title);
            Console.WriteLine(expenseDto.Description);

            Console.WriteLine("Line Items :");
            foreach (ExpenseLineItemDto item in expenseDto.LineItems)
            {
                OutputExpenseLineItem(item);
            }
            Console.WriteLine("--------------------");
        }

        public static void OutputExpenseLineItem(ExpenseLineItemDto expenseLineItemDto)
        {
            Console.WriteLine("{0} ${1}", expenseLineItemDto.Description, expenseLineItemDto.Amount);
        }
    }
}