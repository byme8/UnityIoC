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
    Dependency<SomeMonoBehaviourSettings> settings = new Dependency<SomeMonoBehaviourSettings>();

    public SettingsManager()
    {
        Debug.Log("Settings manager created");
    }

    public string Name
    {
        get
        {
            return "Jek" + this.settings.Value.Count;
        }
    }
}
