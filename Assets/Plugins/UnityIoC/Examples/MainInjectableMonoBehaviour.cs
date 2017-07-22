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

    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(1);

        while (true)
        {
            Debug.Log("Name from resolved dependecy(attribute): " + this.settingsManager.Name);
            yield return wait;
        }
    }
}
