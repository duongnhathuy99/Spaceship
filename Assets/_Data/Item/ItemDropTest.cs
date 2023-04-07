using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropTest : SaiMonoBehaviour
{
    public JunkCtrl junk;
    public int dropCount;
    public List<ItemDropCount> dropCountItems = new List<ItemDropCount>();
    protected virtual void Start() 
    {
        InvokeRepeating(nameof(Dropping),2,1f);
    }
    protected virtual void Dropping()
    {
        dropCount++;
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        List<ItemDropRate> dropItems = ItemDropSpawner.Instance.Drop(junk.ShootableObjectSO.dropList, dropPos, dropRot);
        ItemDropCount itemDropCount;
        foreach (ItemDropRate itemDrop in dropItems) 
        {
            itemDropCount = dropCountItems.Find(i => i.itemName == itemDrop.itemProfileSO.itemName);
            if(itemDropCount==null)
            {
                itemDropCount = new ItemDropCount();
                itemDropCount.itemName = itemDrop.itemProfileSO.itemName;
                dropCountItems.Add(itemDropCount);
            }
            itemDropCount.dropCount++;
            itemDropCount.rate = (float)Math.Round((float)itemDropCount.dropCount / dropCount,3);
        }
    }
    
}
[Serializable]
public class ItemDropCount
{
    public string itemName;
    public int dropCount;
    public float rate;
}