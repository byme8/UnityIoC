using DryIoc;

namespace IoC
{
    /// <summary>
    /// Provides the interface for IoC container setuping.
    /// </summary>
    public interface IContainerSetuper
    {
        /// <summary>
        /// Setups the IoC container.
        /// </summary>
        /// <param name="container">The container.</param>
         void Setup(IContainer container);
    }
}