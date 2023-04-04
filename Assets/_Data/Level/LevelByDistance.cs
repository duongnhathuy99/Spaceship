using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = 0f;
    [SerializeField] protected float distancePerLevel = 10f;
    protected virtual void FixedUpdate()
    {
        Leveling();
    }
    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected virtual void Leveling()
    {
        if (target == null) return;
        distance = Vector3.Distance(transform.position, target.position);
        int newLevel = GetLevelByDistance();
        LevelSet(newLevel);
    }
    protected virtual int GetLevelByDistance()
    {
        return Mathf.FloorToInt(distance / distancePerLevel);
    }
}
