using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    protected override void DespawnObject() 
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
    protected override void ResetValue()
    {
        disLimit = 30;
    }
}
