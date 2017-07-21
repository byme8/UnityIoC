using System;

namespace IoC
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class Dependency : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class Register : Attribute
    {
        public Register(Type interfaceType = null, Reuse reuse = IoC.Reuse.Transient, object key = null)
        {
            this.InterfaceType = interfaceType;
            this.Reuse = reuse;
            this.Key = key;
        }

        public Type InterfaceType { get; private set; }
        public Reuse Reuse { get; private set; }
        public object Key { get; private set; }
    }
}