using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : SaiMonoBehaviour
{
    
    protected virtual void FixedUpdate()
    {
        Despawning();
    }

   
    protected virtual void Despawning()
    {
        if (!CanDesSpawn()) return;
        DespawnObject();
    }
    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }
    protected abstract bool CanDesSpawn();
   
}
