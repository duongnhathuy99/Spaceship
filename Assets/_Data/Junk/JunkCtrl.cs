using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : SaiMonoBehaviour
{
    [SerializeField] protected Transform model;
    public Transform Model { get => model; }

    [SerializeField] protected JunkDespawn junkDespawn;
    public JunkDespawn JunkDespawn { get => junkDespawn; }

    [SerializeField] protected ShootableObjectSO shootableObjectSO;
    public ShootableObjectSO ShootableObjectSO { get => shootableObjectSO; }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
        LoadJunkDespawn();
        LoadShootableObjectSO();
    }
    protected virtual void LoadModel() 
    {
        if (model != null) return;
        model = transform.Find("Model");
        Debug.Log(transform.name + ":Load LoadModel ", gameObject);
    }
    protected virtual void LoadJunkDespawn()
    {
        if (junkDespawn != null) return;
        junkDespawn = transform.GetComponentInChildren<JunkDespawn>();
        Debug.Log(transform.name + ":Load LoadJunkDespawn ", gameObject);
    }
    protected virtual void LoadShootableObjectSO()
    {
        if (shootableObjectSO != null) return;
        string respath = "ShootableObject/Junk/" + transform.name;
        shootableObjectSO = Resources.Load<ShootableObjectSO>(respath);
        Debug.Log(transform.name + ":Load ShootableObjectSO " + respath, gameObject);
    }
}
