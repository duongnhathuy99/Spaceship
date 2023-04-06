using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveForward: ObjMovement
{
    [SerializeField] protected Transform moveTarget;

    protected override void FixedUpdate()
    {
        GetMousePosition();
        base.FixedUpdate();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMoveTarget();
    }
    protected virtual void LoadMoveTarget()
    {
        if (moveTarget != null) return;
        moveTarget = transform.Find("MoveTarget");
        Debug.Log(transform.name + ": Load moveTarget ", gameObject);
    }
    protected virtual void GetMousePosition()
    {
        targetPosition = moveTarget.position;
        targetPosition.z = 0;
    }
}
