using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemySpawner : Spawner
{
    private static EnemySpawner _instance;
    public static EnemySpawner Instance { get => _instance; }

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
