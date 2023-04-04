using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventoryDrop : InventoryAbstract
{
    void Start()
    {
        Invoke(nameof(Test),5);
    }

    protected virtual void Test()
    {
        DropItemIndex(0);
    }
    protected virtual void DropItemIndex(int itemIndex)
    {
        ItemInventory itemInventory = inventory.Items[itemIndex];

        Vector3 dropPos = transform.position;
        dropPos.x += 1;
        ItemDropSpawner.Instance.Drop(itemInventory, dropPos, transform.rotation);
        inventory.Items.Remove(itemInventory);
    }
}