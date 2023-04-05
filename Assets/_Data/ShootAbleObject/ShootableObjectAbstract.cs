using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectAbstract : SaiMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    public ShootableObjectCtrl ShootableObjectSO { get => shootableObjectCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadShootableObjectCtrl();
    }
    protected virtual void LoadShootableObjectCtrl()
    {
        if (shootableObjectCtrl != null) return;
        shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": Load ShootableObjectCtrl ", gameObject);
    }
}
