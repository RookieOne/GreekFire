namespace GreekFire.Foundation.Events
{
    public interface IEventHandler<T>
    {
        void Handle(T domainEvent);
    }
}