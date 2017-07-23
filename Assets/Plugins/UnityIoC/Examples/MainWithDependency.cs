using System.Collections;
using IoC;
using UnityEngine;

public class MainWithDependency : MonoBehaviour
{
    public readonly Dependency<ISettingsManager> SettingsManager;

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(1);

        while (true)
        {
            Debug.Log("Name from resolved dependecy(class): " + this.SettingsManager.Value.Name);
            yield return wait;
        }
    }
}