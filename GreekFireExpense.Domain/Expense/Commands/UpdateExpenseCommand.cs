using System;
using GreekFire.Foundation.Commands;
using GreekFire.Foundation.UnitOfWorks;

namespace GreekFire.Domain
{
    public class UpdateExpenseCommand : ICommand
    {
        private UpdateExpenseDto _updateExpenseDto;

        public UpdateExpenseCommand(UpdateExpenseDto updateExpenseDto)
        {
            _updateExpenseDto = updateExpenseDto;
        }

        public void Execute(IUnitOfWork uow)
        {
            var repository = uow.GetRepository<ExpenseRepository>();

            if (_updateExpenseDto.IsNew)
            {
                var newExpense = NewExpense.create()
                    .withTitle(_updateExpenseDto.Title)
                    .withDescription(_updateExpenseDto.Description)
                    .complete();

                repository.Save(newExpense);
                return;
            }                        
        }
    }
}