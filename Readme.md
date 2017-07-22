# UnityIoC

UnityIoC it's plugin for Unity3D which brings IoC containering to your games.
Here is example how to use it:

Register service:
``` 
public interface ISettingsManager
{
    string Name
    {
        get;
        set;
    }
}

//
// Register singletone of SettingsManager as ISettingsManager.
//
[Register(typeof(ISettingsManager), Reuse.Singletone)]
public class SettingsManager : ISettingsManager
{
    public SettingsManager()
    {
        this.Name = "Jek";
    }

    public string Name
    {
        get;
        set;
    }
}
```

Use registered service in **MonoBehaviour** by inhereting from **InjectableMonoBehaviour**.
```
public class MainInjectableMonoBehaviour : InjectableMonoBehaviour
{
    [Dependency]
    ISettingsManager settingsManager;

    private void Start()
    {
        Debug.Log("Name from resolved dependecy: " + this.settingsManager.Name);
    }
}
```

Use registered service by *container* **Dependency** without inhereting.
```
public class MainWithDependency : MonoBehaviour
{
    Dependency<ISettingsManager> settingsManager;

    private void Start()
    {
        Debug.Log("Name from resolved dependecy(class): " + this.settingsManager.Value.Name);
    }
}
```

According to benchmarks on my machine it cost ~100ms of startup time to find all classes marked with attributes.

When you are inhereting from **InjectableMonoBehaviour** and using **Dependency** attribute to mark dependency it will cost additional 354ns(1ms = 1000ns) to find dependencies for current instance and plus 354ns per dependency to resolve.

When you using *container* **Dependency** method for resolving it will cost 34ns per dependency. That's all, so I would like to recomend you use this method for defining your dependinces.

If you found some bug or have a question don't hesitate to create issues.
