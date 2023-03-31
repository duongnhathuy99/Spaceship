using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAbstract : SaiMonoBehaviour
{
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl { get => itemCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemCtrl();
    }
    protected virtual void LoadItemCtrl()
    {
        if (itemCtrl != null) return;
        itemCtrl = transform.parent.GetComponent<ItemCtrl>();
        //Debug.Log(transform.name + ":Load ItemCtrl ", gameObject);
    }
}
