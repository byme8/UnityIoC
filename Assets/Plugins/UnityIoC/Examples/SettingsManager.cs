using IoC;
using UnityEngine;
using UnityIoC.Examples;

/// <summary>
/// Provides interface for settings manager.
/// </summary>
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

/// <summary>
/// Implementation of <see cref="ISettingsManager"/> with dependencies. 
/// </summary>
[Register(typeof(ISettingsManager), IoC.Reuse.Singletone)]
public class SettingsManager : ISettingsManager
{
    /// <summary>
    /// Holds dependency to <see cref="MonoBehaviour"/> on scene.
    /// </summary>
    public readonly Dependency<SomeMonoBehaviourSettings> Settings;

    /// <summary>
    /// Creates instance of <see cref="SettingsManager"/>
    /// </summary>
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
