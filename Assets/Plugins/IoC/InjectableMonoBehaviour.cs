using System.Text;
using DryIoc;
using UnityEngine;

namespace IoC
{
    public class InjectableMonoBehaviour : MonoBehaviour
    {
        protected virtual void Awake()
        {
            UnityIoC.Container.InjectPropertiesAndFields(this);
        }
    }
}
