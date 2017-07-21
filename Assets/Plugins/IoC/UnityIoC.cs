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

            var a = new Stopwatch();
            a.Start();

            var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(o => o.GetTypes());

            foreach (var type in types)
            {
                var attribute = type.GetCustomAttributes(typeof(Register), false).FirstOrDefault() as Register;
                if (attribute == null)
                    continue;

                Container.Register(attribute.InterfaceType ?? type, type, reuse: attribute.Reuse.ToInstance(), serviceKey: attribute.Key);
            }

            a.Stop();
            UnityEngine.Debug.Log(a.ElapsedMilliseconds);
        }
    }
}
