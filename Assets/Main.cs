using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DryIoc;
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
        this.Name = "jek";
    }

    public string Name
    {
        get;
        set;
    }
}

public class Main : InjectableMonoBehaviour
{
    [Dependency]
    ISettingsManager settingsManager;

    private void Start()
    {
        Debug.Log(this.settingsManager.Name);
    }
}
