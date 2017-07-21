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

Use registered service by *class container* **Dependency** without inhereting.
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



