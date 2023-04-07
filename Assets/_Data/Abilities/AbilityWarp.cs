using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWarp : BaseAbility
{
    [Header("Ability Warp")]
    [SerializeField] protected bool isWarping = false;
    protected Vector4 KeyDirection ;
    
    protected Vector4 warpDirection;
    [SerializeField] protected float warpSpeed = 1f;
    [SerializeField] protected float warpDistance = 1f;

    protected override void Update()
    {
        base.Update();
        CheckWarpDirection();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        Warping();
    }
    protected virtual void CheckWarpDirection()
    {
        if (!isReady) return;
        if (isWarping) return;

        if (KeyDirection.x == 1) WarpLeft();
        if (KeyDirection.y == 1) WarpRight();
        if (KeyDirection.z == 1) WarpUp();
        if (KeyDirection.w == 1) WarpDown();
    }
    protected virtual void WarpLeft()
    {
       
        //Debug.Log("WarpLeft");
        warpDirection.x = 1;
    }
    protected virtual void WarpRight()
    {
        //Debug.Log("WarpRight");
        warpDirection.y = 1;
    }
    protected virtual void WarpUp()
    {
        //Debug.Log("WarpUp");
        warpDirection.z = 1;
    }
    protected virtual void WarpDown()
    {
        //Debug.Log("WarpDown");
        warpDirection.w = 1;
    }
    protected virtual void Warping()
    {
        if (isWarping) return;
        if (IsDirectionNotSet()) return;
        //Debug.Log("Warping");
        isWarping = true;
        Invoke(nameof(WarpFinish),warpSpeed);
    }
    protected virtual bool IsDirectionNotSet()
    {
        return warpDirection.x == 0 && warpDirection.y == 0 && warpDirection.z == 0 && warpDirection.w == 0;
    }
    protected virtual void WarpFinish()
    {
        MoveObj();
        warpDirection.Set(0, 0, 0,0);
        isWarping = false;
        this.Active();
    }
    protected virtual void MoveObj()
    {
        Transform obj = abilities.AbilityObjectCtrl.transform;
        Vector3 newPos = obj.position;
        if (warpDirection.x == 1) newPos.x -= warpDistance;
        if (warpDirection.y == 1) newPos.x += warpDistance;
        if (warpDirection.z == 1) newPos.y += warpDistance;
        if (warpDirection.w == 1) newPos.y -= warpDistance;

        Quaternion fxRot = GetFXQuaternion();
        Transform fx = FXSpawner.Instance.Spawn(FXSpawner.impactBullet, obj.position, fxRot);
        fx.gameObject.SetActive(true);
        obj.position = newPos;
    }

    protected virtual Quaternion GetFXQuaternion()
    {

        Vector3 vector = new Vector3(); ;
        if (warpDirection.x == 1) vector.z = 180;
        if (warpDirection.y == 1) vector.z = 0;
        if (warpDirection.z == 1) vector.z = 90;
        if (warpDirection.w == 1) vector.z = -90;

        if (warpDirection.x == 1 && warpDirection.w == 1) vector.z = -135;
        if (warpDirection.y == 1 && warpDirection.w == 1) vector.z = -45;
        if (warpDirection.x == 1 && warpDirection.z == 1) vector.z = 135;
        if (warpDirection.y == 1 && warpDirection.z == 1) vector.z = 45;

        return Quaternion.Euler(vector);
    }
}
