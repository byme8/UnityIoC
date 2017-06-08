using System;
using System.Collections.Generic;
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
            Container = new Container()
                .With(rules => rules.With(propertiesAndFields: DeclaredPublicProperties));

            var types = typeof(UnityIoC).Assembly.GetTypes();

            RegisterByAttrubute<Register>(types, (type, attribute) => Container.Register(type));
            RegisterByAttrubute<RegisterAs>(types, (type, attribute) => Container.Register(attribute.ServiceType, type));
            RegisterByAttrubute<Singletone.Register>(types, (type, attribute) => Container.Register(type, Reuse.Singleton));
            RegisterByAttrubute<Singletone.RegisterAs>(types, (type, attribute) => Container.Register(attribute.ServiceType, type, Reuse.Singleton));
        }

        public static void RegisterByAttrubute<TAttribute>(Type[] types, Action<Type, TAttribute> register)
            where TAttribute : Attribute
        {
            foreach (var type in types)
            {
                var attribute = type.GetCustomAttributes(typeof(TAttribute), false).FirstOrDefault() as TAttribute;
                if (attribute == null)
                    continue;

                register(type, attribute);
            }
        }

        private static IEnumerable<PropertyOrFieldServiceInfo> DeclaredPublicProperties(Request request)
        {
            return request.ServiceType.GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).
                Where(o => o.GetCustomAttributes(typeof(Inject), true).Any()).
                Select(PropertyOrFieldServiceInfo.Of);
        }

        public static void InjectMembers(this MonoBehaviour monoBehaviour)
        {
            Container.InjectPropertiesAndFields(monoBehaviour);
        }
    }
}
