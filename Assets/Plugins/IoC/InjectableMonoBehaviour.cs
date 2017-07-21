using System.Text;
using DryIoc;
using UnityEngine;

namespace IoC
{
    public class InjectableMonoBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            UnityIoC.Container.InjectPropertiesAndFields(this);
        }
    }
}
