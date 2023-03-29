using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FXSpawner: Spawner
{
    private static FXSpawner _instance;
    public static FXSpawner Instance { get => _instance; }

    public static string smokeOne = "Smoke_1";
    public static string impactBullet = "ImpactBullet";
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
