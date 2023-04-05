using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByDistance: ObjShooting
{
    [Header("Shoot by distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3f;

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }
    protected override bool IsShooting() 
    {
        distance = Vector3.Distance(transform.position, target.position);
        isShooting = distance < shootDistance;
        return isShooting;
    }
}
