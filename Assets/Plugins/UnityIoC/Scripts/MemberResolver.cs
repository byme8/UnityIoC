using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using DryIoc;
using UnityEngine;

namespace IoC
{
    public class MemberResolver
    {
        private readonly Dictionary<Type, PropertyOrFieldServiceInfo[]> cache 
            = new Dictionary<Type, PropertyOrFieldServiceInfo[]>();

        public IEnumerable<PropertyOrFieldServiceInfo> GetMembersToInject(Request request)
        {
            if (!this.cache.ContainsKey(request.ServiceType))
            {
                var members = request.ServiceType.GetMembers(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).
                    Where(o => o.GetCustomAttributes(typeof(DependencyAttribute), true).Any()).
                    Select(PropertyOrFieldServiceInfo.Of).ToArray();
                this.cache.Add(request.ServiceType, members);
            }

            return this.cache[request.ServiceType];
        }
    }
}
