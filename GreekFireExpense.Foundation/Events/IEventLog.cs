namespace GreekFire.Foundation.Events
{
    public  interface IEventLog
    {
        void Log(IDomainEvent domainEvent);
    }
}