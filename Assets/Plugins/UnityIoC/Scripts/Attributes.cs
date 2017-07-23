using System;

namespace IoC
{
    /// <summary>
    /// Attribute for marking dependencies in some class.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class DependencyAttribute : Attribute
    {
    }

    /// <summary>
    /// Attribute for registering types of IoC container.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class Register : Attribute
    {
        /// <summary>
        /// Creates new instance of <see cref="Register"/>.
        /// </summary>
        /// <param name="interfaceType">The insterface type.</param>
        /// <param name="reuse">The kind of instance reusing.</param>
        /// <param name="key">The key of specific instance.</param>
        public Register(Type interfaceType = null, Reuse reuse = IoC.Reuse.Transient, object key = null)
        {
            this.InterfaceType = interfaceType;
            this.Reuse = reuse;
            this.Key = key;
        }

        /// <summary>
        /// Gets the interface type.
        /// </summary>
        /// <returns>The interface type.</returns>
        public Type InterfaceType { get; private set; }
        
        /// <summary>
        /// Gets the kind of instance reusing.
        /// </summary>
        /// <returns>The kind.</returns>
        public Reuse Reuse { get; private set; }

        /// <summary>
        /// Gets the key of specific instance.
        /// </summary>
        /// <returns>The key.</returns>
        public object Key { get; private set; }
    }
}