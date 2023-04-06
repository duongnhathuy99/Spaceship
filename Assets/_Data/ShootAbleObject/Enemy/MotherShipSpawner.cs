using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MotherShipSpawner: Spawner
{
    private static MotherShipSpawner _instance;
    public static MotherShipSpawner Instance { get => _instance; }

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
