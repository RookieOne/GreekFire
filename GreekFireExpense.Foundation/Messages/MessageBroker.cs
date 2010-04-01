using GreekFire.Foundation.Repositories;
using Microsoft.Practices.Unity;

namespace GreekFire.Foundation.Messages
{
    public class MessageBroker : IMessageBroker
    {
        [Dependency]
        public IMessageLog Log { get; set; }

        [Dependency]
        public IMessageConsumerRepository Repository { get; set; }

        [Dependency]
        public IDomainRepository DomainRepository { get; set; }

        public void Handle<T>(T message)
        {
            Log.Log(message as IDomainMessage);

            IConsume<T> messageConsumer = null;

            var aggregateMessage = message as IAggregateMessage;

            if (aggregateMessage != null)
            {
                messageConsumer = DomainRepository.GetAggregate(aggregateMessage.Id) as IConsume<T>;
            }
            else
            {
                messageConsumer = Repository.GetConsumer(message);
            }

            if (messageConsumer != null)
                messageConsumer.Consume(message);
        }
    }
}