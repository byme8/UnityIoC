using System.Text;
using DryIoc;
using UnityEngine;

namespace IoC
{
    public class InjectableMonoBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            this.InjectMembers();
        }
    }
}
