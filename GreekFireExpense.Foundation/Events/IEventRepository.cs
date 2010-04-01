using System;
using System.Collections.Generic;

namespace GreekFire.Foundation.Events
{
    public interface IEventRepository
    {
        void Record(IDomainEvent domainEvent);
        IEnumerable<IDomainEvent> GetEvents(Guid id);
    }
}