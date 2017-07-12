using System;

namespace IoC
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class Inject : Attribute
    {
    }

    public enum Reuse
    {
        Transient,
        Singletone
    }

    public static class ReuseExtentions
    {
        public static DryIoc.IReuse ToInstance(this Reuse reuse)
        {
            switch (reuse)
            {
                case Reuse.Transient:
                    return DryIoc.Reuse.Transient;
                case Reuse.Singletone:
                    return DryIoc.Reuse.Singleton;
            }

            return DryIoc.Reuse.Transient;
        }
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