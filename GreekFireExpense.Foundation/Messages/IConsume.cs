namespace GreekFire.Foundation.Messages
{
    public interface IConsume<T>
    {
        void Consume(T message);
    }
}