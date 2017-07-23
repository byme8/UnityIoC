using IoC;
using UnityEngine;
using UnityIoC.Examples;

public interface ISettingsManager
{
    string Name
    {
        get;
    }

    int Count
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

    public int Count
    {
        get
        {
            return this.Settings.Value.Count;
        }
    }

    public string Name
    {
        get
        {
            return "Jek";
        }
    }
}
