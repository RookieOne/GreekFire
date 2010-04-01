using System;
using System.Collections.Generic;
using GreekFire.Foundation.Events;
using GreekFire.Foundation.Messages;
using Microsoft.Practices.Unity;

namespace GreekFire.Foundation.Repositories
{
    public class DomainRepository
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IEventRepository EventRepository { get; set; }

        public object GetAggregate(Guid id)
        {
            return null;
        }
    }
}