using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : SaiMonoBehaviour
{
    [SerializeField] protected float damage = 10;

    public virtual void Send(Transform obj) 
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        Send(damageReceiver);
        CreateImpactFX();
    }
    public virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(damage);
    }
    protected virtual void CreateImpactFX()
    {
        string fxName = GetImpactFX();

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.impactBullet;
    }
}
