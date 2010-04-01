using System;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows;

namespace GreekFire.Client.Infrastructure.Loaders
{
    /// <summary>
    /// Loads all Page Xaml files in the given assembly into the Merged Dictionary 
    /// collection for the application
    /// </summary>
    public class ResourceDictionaryLoader : IResourceDictionaryLoader
    {
        private Assembly Assembly { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceDictionaryLoader"/> class.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        public ResourceDictionaryLoader(Assembly assembly)
        {
            Assembly = assembly;
        }

        /// <summary>
        /// Loads the resource dictionaries.
        /// </summary>
        public IResourceDictionaryLoader LoadResourceDictionaries()
        {
            string assemblyName = Assembly.GetName().Name;
            Stream stream = Assembly.GetManifestResourceStream(assemblyName + ".g.resources");

            using (var reader = new ResourceReader(stream))
            {
                foreach (DictionaryEntry entry in reader)
                {
                    var key = (string) entry.Key;
                    key = key.Replace(".baml", ".xaml");

                    string uriString = String.Format("pack://application:,,,/{0};Component/{1}", assemblyName, key);

                    var dictionary = new ResourceDictionary
                                         {
                                             Source = new Uri(uriString)
                                         };

                    Application.Current.Resources.MergedDictionaries.Add(dictionary);
                }
            }

            return this;
        }
    }
}