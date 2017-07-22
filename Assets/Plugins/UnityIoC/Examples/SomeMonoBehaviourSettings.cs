using IoC;
using UnityEngine;

namespace UnityIoC.Examples
{
    [Register]
    public class SomeMonoBehaviourSettings : MonoBehaviour
    {
        public int Count;
    }
}