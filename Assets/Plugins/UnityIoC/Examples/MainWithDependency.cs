using System.Collections;
using IoC;
using UnityEngine;

/// <summary>
/// Example of using <see cref="Dependency<TValue>"/> for resolving dependencies.
/// </summary>
public class MainWithDependency : MonoBehaviour
{
    /// <summary>
    /// Some settings manager which will be resolved as dependency.
    /// </summary>
    public readonly Dependency<ISettingsManager> SettingsManager;

    /// <summary>
    /// Starts calculation in play mode.
    /// </summary>
    /// <returns>The enumerator for coroutine.</returns>
    private IEnumerator Start()
    {
        var wait = new WaitForSeconds(1);

        while (true)
        {
            Debug.Log("Name from resolved dependecy(class): " + this.SettingsManager.Value.Name);
            Debug.Log("Count: " + this.SettingsManager.Value.Count);

            yield return wait;
        }
    }
}