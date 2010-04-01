namespace GreekFire.Foundation.Messages
{
    public interface IMessageBroker
    {
        void Handle<T>(T message);        
    }
}