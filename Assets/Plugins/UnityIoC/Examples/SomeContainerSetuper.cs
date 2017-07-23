using System;
using System.Linq;
using DryIoc;
using IoC;
using UnityEngine;

namespace UnityIoC.Examples
{
    /// <summary>
    /// Example of using <see cref="IContainerSetuper"/> for setuping IoC container.
    /// </summary>
    public class SomeContainerSetuper : IContainerSetuper
    {
        /// <summary>
        /// Holds dependency to service.
        /// </summary>
        public readonly Dependency<ISettingsManager> Settings;

        /// <summary>
        /// Setups IoC container.
        /// </summary>
        /// <param name="container">The IoC container.</param>
        public void Setup(IContainer container)
        {
            Debug.Log("Name from setuper: " + this.Settings.Value.Name);
            Debug.Log(string.Format("Registered {0} services", container.GetServiceRegistrations().Count()));
        }
    }
}