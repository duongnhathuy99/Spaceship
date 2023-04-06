using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMovement : SaiMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float distanceMin = 1f;

    protected virtual void FixedUpdate()
    {
        Moving();
    }
    public virtual void SetSpeed(float speed)
    {
        this.speed = speed;
    }
    protected virtual void Moving()
    {
        distance = Vector3.Distance(transform.position, targetPosition);
        if (distance < distanceMin) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
}
