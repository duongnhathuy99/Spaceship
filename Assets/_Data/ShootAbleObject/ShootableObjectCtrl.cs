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
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadDespawn();
        LoadShootableObjectSO();
        LoadObjShooting();
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
    protected virtual void LoadShootableObjectSO()
    {
        if (shootableObjectSO != null) return;
        string respath = "ShootableObject/"+GetObjectTypeString()+"/" + transform.name;
        shootableObjectSO = Resources.Load<ShootableObjectSO>(respath);
        Debug.Log(transform.name + ": ShootableObjectSO " + respath, gameObject);
    }
    protected abstract string GetObjectTypeString();
}
