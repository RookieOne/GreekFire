using Microsoft.Practices.Unity;

namespace GreekFire.Client.Infrastructure.Loaders
{
    /// <summary>
    /// IUnityLoader is an interface describing a loader class which is used to register
    /// types and instances with the passed in Unity Container
    /// </summary>
    public interface IUnityLoader
    {
        /// <summary>
        /// Registers types and instances to the specified container.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <returns>fluent interface, returns this</returns>
        IUnityLoader Register(IUnityContainer container);
    }
}