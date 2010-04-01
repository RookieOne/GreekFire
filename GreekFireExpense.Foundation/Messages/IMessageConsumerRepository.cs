namespace GreekFire.Foundation.Messages
{
    public interface IMessageConsumerRepository
    {
        IConsume<T> GetConsumer<T>(T message);
    }
}