using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JunkSpawner : Spawner
{
    private static JunkSpawner _instance;
    public static JunkSpawner Instance { get => _instance; }

    public static string meteorial = "Meteorial_1";
    public static string meteorialTwo = "Meteorial_2";
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
