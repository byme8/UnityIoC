using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DryIoc;
using UnityEngine;

namespace IoC
{
    /// <summary>
    /// Holds the global container.
    /// </summary>
    public static class UnityIoC
    {
        /// <summary>
        /// The IoC container
        /// </summary>
        public static readonly IContainer Container;

        /// <summary>
        /// Setups the IoC container.
        /// </summary>
        static UnityIoC()
        {
            var memberResolver = new MemberResolver();

            Container = new Container()
                .With(rules => rules.With(propertiesAndFields: memberResolver.GetMembersToInject));

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes());

            var setupers = new List<Type>();
            foreach (var type in types)
            {
                //
                // Searching the all custotm container setupers.  
                //
                if (type.ImplementsServiceType(typeof(IContainerSetuper)))
                {
                    setupers.Add(type);
                    Container.Register(type);
                }

                //
                // Handeling all types with Register attribute. 
                //
                var attribute = type.GetCustomAttributes(typeof(Register), false).FirstOrDefault() as Register;
                if (attribute == null)
                    continue;

                //
                // If type inherited from MonoBehaviour then we should find it on scene.
                //
                if (type.ImplementsServiceType(typeof(MonoBehaviour)))
                {
                    RegisterUnityMonoBehaviour(type);
                    continue;
                }

                //
                // Registering all other types marked with attribute.
                //
                RegisterOtherTypes(type, attribute);
            }

            foreach (var setuper in setupers)
            {
                var containerSetuper = Container.Resolve(setuper) as IContainerSetuper;
                containerSetuper.Setup(Container);
            }
        }

        /// <summary>
        /// Registering type to container.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="attribute">The attibute with data.</param>
        private static void RegisterOtherTypes(Type type, Register attribute)
        {
            Container.Register(
                serviceType: attribute.InterfaceType ?? type,
                implementationType: type,
                reuse: attribute.Reuse.ToInstance(),
                serviceKey: attribute.Key);
        }

        /// <summary>
         /// Registering <see cref="MonoBehaviour"/> for search it on scene.
        /// </summary>
        /// <param name="type">The type.</param>
        private static void RegisterUnityMonoBehaviour(Type type)
        {
            Container.RegisterDelegate(
                serviceType: type,
                factoryDelegate: o => GameObject.FindObjectOfType(type),
                reuse: DryIoc.Reuse.Singleton);
        }
    }
}
