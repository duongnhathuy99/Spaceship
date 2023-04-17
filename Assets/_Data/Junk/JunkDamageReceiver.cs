using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk Damage Receiver")]

    [SerializeField] protected JunkCtrl junkCtrl;
    protected override void LoadComponents()
    {
        LoadJunkCtrl();
        LoadSphereCollider();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ":Load JunkCtrl ", gameObject);
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = transform.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.4f;
        Debug.Log(transform.name + ":Load SphereCollider ", gameObject);
    }
    protected override void OnDead()
    {
        OnDeadFX();
        OnDropDead();
        junkCtrl.JunkDespawn.DespawnObject();
    }
    protected virtual void OnDropDead()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(junkCtrl.ShootableObjectSO.dropList, dropPos, dropRot);
    }
    protected virtual void OnDeadFX()
    {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }
    protected override void Reborn()
    {
        hpmax = junkCtrl.ShootableObjectSO.hpMax;
        base.Reborn();
    }
}
