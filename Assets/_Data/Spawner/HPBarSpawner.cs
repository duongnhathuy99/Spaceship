using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HPBarSpawner: Spawner
{
    private static HPBarSpawner _instance;
    public static HPBarSpawner Instance { get => _instance; }

    public static string HPBar = "HPBar";
    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}
