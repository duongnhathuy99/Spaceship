using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn { get => despawn; }

    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO { get => shootableObjectSO; }

    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting { get => objShooting; }

    [SerializeField] protected ObjMovement objMovement;
    public ObjMovement ObjMovement { get => objMovement; }

    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget ObjLookAtTarget { get => objLookAtTarget; }

    [SerializeField] protected Spawner spawner;
    public Spawner Spawner { get => spawner; }

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver { get => damageReceiver; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadDespawn();
        LoadShootableObjectSO();
        LoadObjShooting();
        LoadObjMovement();
        LoadObjLookAtTarget();
        LoadSpawner();
        LoadDamageReceiver();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel ", gameObject);
    }
    protected virtual void LoadObjShooting()
    {
        if (objShooting != null) return;
        objShooting = transform.GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": LoadObjShooting ", gameObject);
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadDespawn ", gameObject);
    }
    protected virtual void LoadObjMovement()
    {
        if (objMovement != null) return;
        objMovement = transform.GetComponentInChildren<ObjMovement>();
        Debug.Log(transform.name + ": Load objMovement ", gameObject);
    }
    protected virtual void LoadObjLookAtTarget()
    {
        if (objLookAtTarget != null) return;
        objLookAtTarget = transform.GetComponentInChildren<ObjLookAtTarget>();
        Debug.Log(transform.name + ": Load objLookAtTarget ", gameObject);
    }
    protected virtual void LoadShootableObjectSO()
    {
        if (shootableObjectSO != null) return;
        string respath = "ShootableObject/"+GetObjectTypeString()+"/" + transform.name;
        shootableObjectSO = Resources.Load<ShootableObjectSO>(respath);
        Debug.Log(transform.name + ": ShootableObjectSO " + respath, gameObject);
    }
    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform.name + ": Load Spawner ", gameObject);
    }
    protected virtual void LoadDamageReceiver()
    {
        if (damageReceiver != null) return;
        damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": Load damageReceiver ", gameObject);
    }
    
    protected abstract string GetObjectTypeString();
}
