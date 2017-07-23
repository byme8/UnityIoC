using IoC;
using UnityEngine;
using UnityIoC.Examples;

public interface ISettingsManager
{
    string Name
    {
        get;
    }
}

[Register(typeof(ISettingsManager), IoC.Reuse.Singletone)]
public class SettingsManager : ISettingsManager
{
    public readonly Dependency<SomeMonoBehaviourSettings> Settings;

    public SettingsManager()
    {
        Debug.Log("Settings manager created");
    }

    public string Name
    {
        get
        {
            return "Jek" + this.Settings.Value.Count;
        }
    }
}
