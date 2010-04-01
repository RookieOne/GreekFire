using System;
using System.Reflection;
using GreekFire.Foundation.Messages;
using Microsoft.Practices.Unity;

namespace GreekFire.Foundation.Repositories
{
    public class UnityMessageConsumerRepository : IMessageConsumerRepository
    {
        private readonly IUnityContainer _container;

        public UnityMessageConsumerRepository()
        {
            _container = new UnityContainer();
        }

        public void RegisterAssembly(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                Type[] interfaces = type.GetInterfaces();

                foreach (Type i in interfaces)
                {
                    if (i.IsGenericType)
                    {
                        Type[] c = i.GetGenericArguments();

                        Type gType = c[0];

                        if (gType.GetInterface("IDomainMessage") != null)
                        {
                            string messageName = gType.Name;
                            _container.RegisterType(i, type, messageName);
                        }
                    }
                }
            }
        }

        public IConsume<T> GetConsumer<T>(T message)
        {
            Type genericType = typeof (IConsume<>);

            Type consumerType = genericType.MakeGenericType(new[] {message.GetType()});

            return _container.Resolve(consumerType, message.GetType().Name) as IConsume<T>;
        }
    }
}