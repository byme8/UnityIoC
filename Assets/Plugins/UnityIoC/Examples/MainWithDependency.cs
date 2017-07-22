using System.Collections;
using IoC;
using UnityEngine;

public class MainWithDependency : MonoBehaviour
{
    Dependency<ISettingsManager> settingsManager = new Dependency<ISettingsManager>();

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(1);

        while (true)
        {
            Debug.Log("Name from resolved dependecy(class): " + this.settingsManager.Value.Name);
            yield return wait;
        }
    }
}