using IoC;
using UnityEngine;

public class MainWithDependency : MonoBehaviour
{
    Dependency<ISettingsManager> settingsManager;

    private void Start()
    {
        Debug.Log("Name from resolved dependecy(class): " +this.settingsManager.Value.Name);
    }
}