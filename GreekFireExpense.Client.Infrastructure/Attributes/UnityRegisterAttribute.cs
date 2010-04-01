using System;

namespace GreekFire.Client.Infrastructure.Attributes
{
    /// <summary>
    /// Attribute used to mark a class to be registered with the Unity Container.
    /// The Type is the type the class should be registered to with the Unity container
    /// </summary>
    public class UnityRegisterAttribute : Attribute
    {
        public Type Type { get; set; }

        public UnityRegisterAttribute(Type type)
        {
            Type = type;
        }
    }
}