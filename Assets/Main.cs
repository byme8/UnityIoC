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

[Singletone.RegisterAs(typeof(ISettingsManager))]
public class SettingsManager : ISettingsManager
{
    public SettingsManager()
    {
        this.Name = "jek";
    }

    public string Name
    {
        get;
        set;
    }
}

[Register]
public class Main : InjectableMonoBehaviour
{
    [Inject]
    ISettingsManager settingsManager;

    private void Start()
    {
        Debug.Log(this.settingsManager.Name);
    }
}
