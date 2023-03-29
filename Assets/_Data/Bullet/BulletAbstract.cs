using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletAbstract : SaiMonoBehaviour
{
    [Header("Buller Abstract")]
    [SerializeField] protected BulletCtrl bulletCtrl;
    public BulletCtrl BulletCtrl { get => bulletCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ":Load BulletCtrl ", gameObject);
    }
}
