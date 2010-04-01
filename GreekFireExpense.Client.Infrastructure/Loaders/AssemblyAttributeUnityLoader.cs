using System;
using System.Linq;
using System.Reflection;
using GreekFire.Client.Infrastructure.Attributes;
using Microsoft.Practices.Unity;

namespace GreekFire.Client.Infrastructure.Loaders
{
    /// <summary>
    /// Loads and registers types in assembly that have the UnityRegisterAttribute
    /// </summary>
    public class AssemblyAttributeUnityLoader : IUnityLoader
    {
        private Assembly Assembly { get; set; }

        /// <summary>
        /// Constructor for AssemblyAttributeUnityLoader
        /// </summary>
        /// <param name="assemblyToLoad"></param>
        public AssemblyAttributeUnityLoader(Assembly assemblyToLoad)
        {
            Assembly = assemblyToLoad;
        }

        /// <summary>
        /// Register all types that have the UnityRegisterAttribute
        /// </summary>
        /// <param name="container"></param>
        public IUnityLoader Register(IUnityContainer container)
        {
            if (Assembly == null)
                return this;

            Type[] types = Assembly.GetTypes();

            for (int t = 0; t < types.Count(); t++)
            {
                Type currentType = types[t];

                if (currentType.IsClass)
                {
                    object[] attributes = currentType.GetCustomAttributes(typeof (UnityRegisterAttribute), false);

                    if (attributes.Count() > 0)
                    {
                        var attribute = attributes[0] as UnityRegisterAttribute;

                        if (attribute != null)
                        {
                            container.RegisterType(attribute.Type, currentType);
                        }
                    }
                }
            }

            return this;
        }
    }
}