using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : SaiMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn { get => itemDespawn; }

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory { get => itemInventory; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadItemDespawn();
        LoadItemInventory();
    }
    protected void OnEnable()
    {
        ResetItem();
    }
    protected virtual void LoadItemDespawn()
    {
        if (itemDespawn != null) return;
        itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ":Load ItemDespawn ", gameObject);
    }
    public virtual void SetItemInventoryDrop(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }
    protected virtual void LoadItemInventory()
    {
        if (itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        itemInventory.itemProfile = itemProfile;
        ResetItem();
        Debug.Log(transform.name + ":Load itemInventory ", gameObject);
    }
    protected virtual void ResetItem()
    {
        itemInventory.itemCount = 1;
        itemInventory.upgradeLevel = 0;
    }
}
