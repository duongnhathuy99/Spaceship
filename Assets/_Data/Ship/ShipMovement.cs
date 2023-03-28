using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.1f;
    void FixedUpdate()
    {
        GetTargetPosition();
        LookAtTarget();
        Moving();
    }

    protected virtual void GetTargetPosition()
    {
        targetPosition = InputManager.Instance.MouseWorldPosition;
        targetPosition.z = 0;
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);
    }
    protected virtual void Moving()
    {
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
}