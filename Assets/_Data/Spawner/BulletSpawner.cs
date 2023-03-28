using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BulletSpawner : Spawner
{
    private static BulletSpawner _instance;
    public static BulletSpawner Instance { get => _instance; }

    public static string bulletOne = "Bullet";
    public static string bulletTwo = "Bullet (1)";
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
