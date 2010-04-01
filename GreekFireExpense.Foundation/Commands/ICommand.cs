using GreekFire.Foundation.UnitOfWorks;

namespace GreekFire.Foundation.Commands
{
    public interface ICommand
    {
        void Execute(IUnitOfWork uow);
    }
}