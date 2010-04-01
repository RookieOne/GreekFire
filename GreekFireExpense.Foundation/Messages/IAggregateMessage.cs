using System;

namespace GreekFire.Foundation.Messages
{
    public interface IAggregateMessage : IDomainMessage
    {
        Guid Id { get; }
    }
}