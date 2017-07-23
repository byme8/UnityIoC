using DryIoc;

namespace IoC
{
    /// <summary>
    /// Represents the dependency.
    /// </summary>
    public struct Dependency<TValue>
        where TValue : class
    {
        /// <summary>
        /// Cache field for resolved dependency.
        /// </summary>
        private TValue value;

        /// <summary>
        /// Gets the resolved dependency
        /// </summary>
        /// <returns>The dependency.</returns>
        public TValue Value
        {
            get
            {
                return this.value ?? (this.value = UnityIoC.Container.Resolve<TValue>());
            }
        }
    }
}