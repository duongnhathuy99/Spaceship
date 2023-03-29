using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDespawn : DespawnByDistance
{
    public override void DespawnObject() 
    {
        JunkSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        disLimit = 40;
    }
}
