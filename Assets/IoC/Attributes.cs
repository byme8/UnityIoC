using System;

namespace IoC
{
    public static class Singletone
    {
        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
        public class Register : Attribute
        {
        }

        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
        public class RegisterAs : Attribute
        {
            public Type ServiceType
            {
                get;
                private set;
            }

            public RegisterAs(Type serviceType)
            {
                this.ServiceType = serviceType;
            }
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class Inject : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class Register : Attribute
    {
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class RegisterAs : Attribute
    {
        public Type ServiceType
        {
            get;
            private set;
        }

        public RegisterAs(Type serviceType)
        {
            this.ServiceType = serviceType;
        }
    }
}