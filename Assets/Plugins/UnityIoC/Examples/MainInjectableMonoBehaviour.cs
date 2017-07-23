using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DryIoc;
using IoC;
using UnityEngine;

/// <summary>
/// Example of using <see cref="InjectableMonoBehaviour"/> and <see cref="Dependency"/> attribute.
/// </summary>
public class MainInjectableMonoBehaviour : InjectableMonoBehaviour
{
    /// <summary>
    /// Some settings manager which will be resolved as dependency.
    /// </summary>
    [Dependency]
    ISettingsManager settingsManager;

    /// <summary>
    /// Starts calculation in play mode.
    /// </summary>
    /// <returns>The enumerator for coroutine.</returns>
    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(1);

        while (true)
        {
            Debug.Log("Name from resolved dependecy(attribute): " + this.settingsManager.Name);
            Debug.Log("Count: " + this.settingsManager.Count);
            yield return wait;
        }
    }
}
