using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner _instance;
    public static ItemDropSpawner Instance { get => _instance; }

   
    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = dropList[0].itemProfileSO.itemCode;
        Transform itemDrop = Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        ItemCode itemCode = itemInventory.itemProfile.itemCode;
        Transform itemDrop = Spawn(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        ItemCtrl itemCtrl = itemDrop.GetComponent<ItemCtrl>();
        itemCtrl.SetItemInventoryDrop(itemInventory);
        return itemDrop;
    }
}
