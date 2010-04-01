using System;

namespace GreekFire.Foundation.Repositories
{
    public interface IDomainRepository
    {
        object GetAggregate(Guid id);
    }
}