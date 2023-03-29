using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected SphereCollider sphereCollider;
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
        junkCtrl.JunkDespawn.DespawnObject();
    }
    protected virtual void OnDeadFX()
    {
        string fxName = GetOnDeadFXName();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName,transform.position,transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }
    protected virtual string GetOnDeadFXName()
    {
        return FXSpawner.smokeOne;
    }
    protected override void Reborn()
    {
        hpmax = junkCtrl.JunkSO.hpMax;
        base.Reborn();
    }

}
