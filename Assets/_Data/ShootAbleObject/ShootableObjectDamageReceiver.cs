using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  ShootableObjectDamageReceiver: DamageReceiver
{
    [Header("Shootable Object DamageReceiver")]

    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    protected override void LoadComponents()
    {
        LoadShootableObjectCtrl();
        LoadSphereCollider();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (shootableObjectCtrl != null) return;
        shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ":Load ShootableObjectCtrl ", gameObject);
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
        shootableObjectCtrl.Despawn.DespawnObject();
    }
    protected virtual void OnDropDead()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(shootableObjectCtrl.ShootableObjectSO.dropList, dropPos, dropRot);
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
        hpmax = shootableObjectCtrl.ShootableObjectSO.hpMax;
        base.Reborn();
    }
}
