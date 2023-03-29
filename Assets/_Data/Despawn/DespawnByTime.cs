using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float delay = 2f;
    [SerializeField] protected float timer = 0f;

    
    protected void OnEnable()
    {
        ResetTimer();
    }

    protected virtual void ResetTimer()
    {
        timer = 0;
    }
    protected override bool CanDesSpawn()
    {
        timer += Time.fixedDeltaTime;
        if (timer > delay) return true;
        return false;
    }
}
