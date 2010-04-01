namespace GreekFire.Foundation.Messages
{
    public interface IMessageLog
    {
        void Log(IDomainMessage message);
    }
}