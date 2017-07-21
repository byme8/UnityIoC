using IoC;
using UnityEngine;

public class MainClean : MonoBehaviour
{
    Dependency<ISettingsManager> settingsManager;

    private void Start()
    {
        Debug.Log(this.settingsManager.Value.Name);
    }
}