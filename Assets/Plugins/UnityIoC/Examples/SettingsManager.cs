using IoC;
using UnityEngine;


public interface ISettingsManager
{
    string Name
    {
        get;
        set;
    }
}

[Register(typeof(ISettingsManager), IoC.Reuse.Singletone)]
public class SettingsManager : ISettingsManager
{
    public SettingsManager()
    {
        Debug.Log("Settings manager created");
        this.Name = "Jek";
    }

    public string Name
    {
        get;
        set;
    }
}
