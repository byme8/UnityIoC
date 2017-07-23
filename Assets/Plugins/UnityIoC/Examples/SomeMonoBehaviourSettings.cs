using IoC;
using UnityEngine;

namespace UnityIoC.Examples
{
    /// <summary>
    /// Example of some <see cref="MonoBehaviour"/> settings on scene.
    /// </summary>
    [Register]
    public class SomeMonoBehaviourSettings : MonoBehaviour
    {
        public int Count;
    }
}