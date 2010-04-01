using GreekFire.Foundation.RepositoryStrategies;

namespace GreekFire.Foundation.UnitOfWorks
{
    /// <summary>
    /// Strategy Register is responsible for maintaining a cache of repository strategies
    /// </summary>
    public interface IStrategyRegister 
    {
        /// <summary>
        /// Registers the specified strategy with the strategy register.
        /// </summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns></returns>
        IStrategyRegister Register(IRepositoryStrategy strategy);
    }
}