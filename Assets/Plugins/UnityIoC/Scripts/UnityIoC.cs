using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using DryIoc;
using UnityEngine;

namespace IoC
{
    public static class UnityIoC
    {
        public static readonly IContainer Container;

        static UnityIoC()
        {
            var memberResolver = new MemberResolver();

            Container = new Container()
                .With(rules => rules.With(propertiesAndFields: memberResolver.GetMembersToInject));

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes());

            var setupers = new List<Type>();
            foreach (var type in types)
            {
                if (type.ImplementsServiceType(typeof(IContainerSetuper)))
                {
                    setupers.Add(type);
                    Container.Register(type);
                }

                var attribute = type.GetCustomAttributes(typeof(Register), false).FirstOrDefault() as Register;
                if (attribute == null)
                    continue;

                if (type.ImplementsServiceType(typeof(MonoBehaviour)))
                {
                    RegisterUnityMonoBehaviour(type);
                    continue;
                }

                RegisterOtherTypes(type, attribute);
            }

            foreach (var setuper in setupers)
            {
                var containerSetuper = Container.Resolve(setuper) as IContainerSetuper;
                containerSetuper.Setup(Container);
            }
        }

        private static void RegisterOtherTypes(Type type, Register attribute)
        {
            Container.Register(
                serviceType: attribute.InterfaceType ?? type,
                implementationType: type,
                reuse: attribute.Reuse.ToInstance(),
                serviceKey: attribute.Key);
        }

        private static void RegisterUnityMonoBehaviour(Type type)
        {
            Container.RegisterDelegate(
                serviceType: type,
                factoryDelegate: o => GameObject.FindObjectOfType(type),
                reuse: DryIoc.Reuse.Singleton);
        }
    }
}
