using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using AutoMapper;
using GreekFireExpense.Console;
using GreekFireExpense.Data.EntityFramework;
using GreekFireExpense.Data.EntityFramework.Converters;
using GreekFireExpense.Data.EntityFramework.RepositoryStrategies;
using GreekFireExpense.Domain;
using GreekFireExpense.Foundation.Repository;
using GreekFireExpense.Foundation.UnitOfWorks;
using Microsoft.Practices.Unity;

namespace GreekFireExpenseConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConfigureContainerAndUow();

            InsertExpensive();

            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository<ExpenseRepository>();

                var expenses = repository.GetImportantExpenses();

                foreach (var e in expenses)
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Title);
                    Console.WriteLine(e.Description);

                    foreach (var item in e.LineItems)
                    {
                        Console.WriteLine(item.Description);
                        Console.WriteLine(item.Amount);
                    }
                    Console.ReadLine();
                }

            }

            //using (var uow = new UnitOfWork())
            //{
            //    var repository = uow.GetRepository<ExpenseRepository>();

            //    var expenses = repository.GetExpenses();

            //    foreach(var e in expenses)
            //    {
            //        Console.WriteLine();
            //        Console.WriteLine(e.Title);
            //        Console.WriteLine(e.Description);

            //        foreach(var item in e.LineItems)
            //        {
            //            Console.WriteLine(item.Description);
            //            Console.WriteLine(item.Amount);
            //        }
            //        Console.ReadLine();
            //    }
                
            //}
            
            Console.WriteLine("DONE");
            Console.ReadLine();
        }

        private static void InsertExpensive()
        {            
            var item = new ExpenseLineItem { Amount = 3000, Description = "Expensive Item" };

            var expense = new Expense
            {
                Description = "Expensive Description",
                Title = "Expensive Title"
            };
            expense.AddLineItem(item);

            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository<ExpenseRepository>();

                repository.Save(expense);

                uow.Commit();
            }
        }

        private static void InsertWithItems()
        {
            var item1 = new ExpenseLineItem { Amount = 10, Description = "Item 1" };
            var item2 = new ExpenseLineItem { Amount = 300, Description = "Item 2" };

            var expense = new Expense
            {
                Description = "Expense",
                Title = "Title"
            };
            expense.AddLineItem(item1);
            expense.AddLineItem(item2);

            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository<ExpenseRepository>();

                repository.Save(expense);

                uow.Commit();
            }
        }


        private static void Insert()
        {
            DisplayDatabase();

            DisplayRepository();

            using (var uow = new UnitOfWork())
            {
                var myExpense = new Expense
                {
                    Description = "Test",
                    Title = "Title"
                };

                var repository = uow.GetRepository<ExpenseRepository>();
                repository.Save(myExpense);
                uow.Commit();
            }

            DisplayDatabase();

            DisplayRepository();
        }

        private static void ConfigureContainerAndUow()
        {
            var repositoryContainer = new UnityContainer();

            repositoryContainer.RegisterType<ExpenseRepository, ExpenseRepository>();

            var lifetimeManager = new ContainerControlledLifetimeManager();
            repositoryContainer.RegisterType<IRepositoryStrategy, EntityFrameworkRepositoryStrategy>("ExpenseDatabase",
                                                                                                     lifetimeManager);

            UnitOfWork.SetRepositoryContainer(repositoryContainer);
        }

        private static void DisplayDatabase()
        {
            Console.WriteLine("In database ...");
            var db = new GreekFireExpenseDBEntities();
            foreach (var expense in db.Expenses)
                Console.WriteLine(expense.Title);

            Console.WriteLine("....");
            Console.ReadLine();
        }

        private static void DisplayRepository()
        {
            Console.WriteLine("In repository ...");

            using (var uow = new UnitOfWork())
            {
                var repository = uow.GetRepository<ExpenseRepository>();

                IEnumerable<Expense> expenses = repository.GetExpenses();

                foreach (Expense expense in expenses)
                    Console.WriteLine(expense.Title);
            }

            Console.WriteLine("....");
            Console.ReadLine();
        }
    }
}