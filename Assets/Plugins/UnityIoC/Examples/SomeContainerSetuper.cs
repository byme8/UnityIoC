using System;
using System.Linq;
using DryIoc;
using IoC;
using UnityEngine;

namespace UnityIoC.Examples
{
    public class SomeContainerSetuper : IContainerSetuper
    {
        public readonly Dependency<ISettingsManager> Settings;

        public void Setup(IContainer container)
        {
            Debug.Log("Name from setuper: " + this.Settings.Value.Name);
            Debug.Log(string.Format("Registered {0} services", container.GetServiceRegistrations().Count()));
        }
    }
}