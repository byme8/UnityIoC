using System.Text;
using DryIoc;
using UnityEngine;

namespace IoC
{
    /// <summary>
    /// Provides base class for <see cref="MonoBehaviour"/> with dependecies.
    /// </summary>
    public class InjectableMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            UnityIoC.Container.InjectPropertiesAndFields(this);
        }
    }
}
