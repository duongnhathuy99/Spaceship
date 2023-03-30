using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupAble itemPickupAble)
    {
        ItemCode itemCode = itemPickupAble.GetItemCode();
        if (playerCtrl.CurrentShip.Inventory.AddItem(itemCode, 1))
        {
            itemPickupAble.Picked();
        }
            
    }
}
