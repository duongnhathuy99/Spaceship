using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : SaiMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn { get => itemDespawn; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
    }
   
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ":Load ItemDespawn ", gameObject);
    }
}
