using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SaiMonoBehaviour
{
    [SerializeField] protected int maxSlot = 70;
    [SerializeField] protected List<ItemInventory> items;
    private void Start()
    {
        AddItem(ItemCode.SilvelOre,3);
    }

    public virtual bool AddItem(ItemCode itemCode, int addCount) 
    {
        ItemInventory itemInventory = GetItemByCode(itemCode);
        int newCount = itemInventory.itemCount + addCount;
        if (newCount > itemInventory.maxStack) return false;
        itemInventory.itemCount = newCount;
        return true;
    }
    public virtual ItemInventory GetItemByCode (ItemCode itemCode)
    {
        ItemInventory itemInventory = items.Find((item) => item.itemProfile.itemCode == itemCode);
        if (itemInventory == null) itemInventory = AddEmptyProfile(itemCode);
        return itemInventory;
    }

    protected virtual ItemInventory AddEmptyProfile(ItemCode itemCode) 
    {
        var profiles = Resources.LoadAll("ItemProfiles",typeof(ItemProfileSO));
        foreach (ItemProfileSO profileSO in profiles)
        {
            if (profileSO.itemCode != itemCode) continue;
            ItemInventory itemInventory = new ItemInventory
            {
                itemProfile = profileSO,
                maxStack = profileSO.defaultMaxStack,
            };
            items.Add(itemInventory);
            return itemInventory;
        }
        return null;
    }
}
