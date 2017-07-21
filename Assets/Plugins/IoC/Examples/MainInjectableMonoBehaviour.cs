using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DryIoc;
using IoC;
using UnityEngine;

public class MainInjectableMonoBehaviour : InjectableMonoBehaviour
{
    [Dependency]
    ISettingsManager settingsManager;

    private void Start()
    {
        Debug.Log("Name from resolved dependecy(attribute): " +this.settingsManager.Name);
    }
}
