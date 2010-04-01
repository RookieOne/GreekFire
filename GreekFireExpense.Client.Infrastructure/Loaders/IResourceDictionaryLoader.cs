namespace GreekFire.Client.Infrastructure.Loaders
{
    /// <summary>
    /// Interface for ResourceDictionaryLoader.
    /// ResoruceDictionaryLoaders should load Resource Dictionaries into the
    /// Application
    /// </summary>
    public interface IResourceDictionaryLoader
    {
        /// <summary>
        /// Loads the resource dictionaries into the application.
        /// </summary>
        /// <returns></returns>
        IResourceDictionaryLoader LoadResourceDictionaries();
    }
}