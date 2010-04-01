using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;

namespace GreekFire.Foundation.Extensions
{
    /// <summary>
    /// Erwin Van Der Valk has written an extension that allows one to test if a 
    /// type is registered with Unity. The UnityContainerExtension, called QueryableContainerExtension, 
    /// hooks into the Registering Event of the Context Class that fires each time a type is 
    /// registered with the container.
    /// (http://www.pnpguidance.net/post/TestingIfTypeHasBeenRegisteredWithUnityPatternsPractices.aspx)
    /// </summary>
    public class QueryableContainerExtension : UnityContainerExtension
    {
        public List<RegisterEventArgs> Registrations = new List<RegisterEventArgs>();

        protected override void Initialize()
        {
            Context.Registering += Context_Registering;
        }

        private void Context_Registering(object sender, RegisterEventArgs e)
        {
            Registrations.Add(e);
        }

        public bool IsTypeRegistered<TFrom, TTo>()
        {
            return Registrations.FirstOrDefault((e) => e.TypeFrom == typeof (TFrom)
                                                       && e.TypeTo == typeof (TTo)) != null;
        }

        public bool IsTypeRegisteredAsSingleton<TFrom, TTo>()
        {
            return Registrations.FirstOrDefault((e) => e.TypeFrom == typeof (TFrom)
                                                       && e.TypeTo == typeof (TTo)
                                                       &&
                                                       typeof (ContainerControlledLifetimeManager).IsInstanceOfType(
                                                           e.LifetimeManager)) != null;
        }
    }
}