using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupAble itemPickupAble)
    {
        ItemCode itemCode = itemPickupAble.GetItemCode();
        ItemInventory itemInventory = itemPickupAble.ItemCtrl.ItemInventory;
        if (playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupAble.Picked();
        }
            
    }
}
