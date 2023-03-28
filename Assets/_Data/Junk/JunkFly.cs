using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkFly : ParentFly
{

    [SerializeField] protected float minCamPos = -20f;
    [SerializeField] protected float maxCamPos = 20f;
    protected override void ResetValue()
    {
        moveSpeed = 0.5f;
    }
    protected void OnEnable()
    {
        GetFlyDirection();
    }
    protected virtual void GetFlyDirection() 
    {
        Vector3 camPos = GameCrtl.Instance.MainCamera.transform.position;
        Vector3 objPos = transform.parent.position;
        camPos.x += Random.Range(minCamPos,maxCamPos);
        camPos.y += Random.Range(minCamPos, maxCamPos);
        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rot_z);

        Debug.DrawLine(objPos, objPos + diff * 10, Color.red, Mathf.Infinity);
        //Debug.DrawLine(objPos, camPos, Color.red, Mathf.Infinity);
    }
}
