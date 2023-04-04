using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : SaiMonoBehaviour
{
    [SerializeField] protected int maxSlot = 7;
    [SerializeField] protected List<ItemInventory> items;
    public List<ItemInventory> Items => items;
    private void Start()
    {
        AddItem(ItemCode.IronSword, 1);
        AddItem(ItemCode.SilvelOre, 7);
        AddItem(ItemCode.IronOre, 7);
    }
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        int addCount = itemInventory.itemCount;
        ItemProfileSO itemProfile = itemInventory.itemProfile;
        ItemCode itemCode = itemProfile.itemCode;
        ItemType itemType = itemProfile.itemType;

        if (itemType == ItemType.Equiment) return AddEquipment(itemInventory);
        return AddItem(itemCode, addCount);
    }
    public virtual bool AddEquipment(ItemInventory itemInventory)
    {
        if (IsInventoryFull()) return false;
        ItemInventory item = itemInventory.Clone();
        items.Add(item);
        return true;
    }
    public virtual bool AddItem(ItemCode itemCode, int addCount) 
    {
        ItemProfileSO itemProfileSO = GetItemProfile(itemCode);
        int addRemain = addCount;
        int newCount;
        int itemMaxStack;
        int addMore;
        ItemInventory itemExist;
        for (int i = 0; i < maxSlot; i++)
        {
            itemExist = GetItemNotFullStack(itemCode);
            if (itemExist == null)
            {
                if (IsInventoryFull()) return false;
                itemExist = CreatEmptyItem(itemProfileSO);
                items.Add(itemExist);
            }
            newCount = itemExist.itemCount + addRemain;

            itemMaxStack = GetMaxStack(itemExist);
            if (newCount > itemMaxStack)
            {
                addMore = itemMaxStack - itemExist.itemCount;
                newCount = itemExist.itemCount + addMore;
                addRemain -= addMore;
            }
            else 
            {
                addRemain -= newCount;
            }
            itemExist.itemCount = newCount;
            if (addRemain < 1) break;
        }
        
        return true;
    }

    protected virtual bool IsInventoryFull() 
    {
        if(items.Count>=maxSlot) return true;
        return false;
    }
    protected virtual int GetMaxStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return 0;
        return itemInventory.maxStack;
    }
    public virtual ItemProfileSO GetItemProfile (ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profileSO in profiles)
        {
            if (profileSO.itemCode != itemCode) continue;
            return profileSO;
        }
        return null;
    }

    protected virtual ItemInventory GetItemNotFullStack(ItemCode itemCode)
    {
        foreach (ItemInventory itemIventory in items)
        {
            if (itemCode != itemIventory.itemProfile.itemCode) continue;
            if (IsFullStack(itemIventory)) continue;
            return itemIventory;

        }
        return null;
    }

    protected virtual bool IsFullStack(ItemInventory itemInventory)
    {
        if (itemInventory == null) return true;
        int maxStack = GetMaxStack(itemInventory);
        return itemInventory.itemCount >= maxStack;
    }
    protected virtual ItemInventory CreatEmptyItem(ItemProfileSO itemProfileSO)
    {
        ItemInventory itemInventory = new ItemInventory
        {
            itemProfile = itemProfileSO,
            maxStack = itemProfileSO.defaultMaxStack,
        };
        return itemInventory;
    }

    public virtual bool ItemCheck(ItemCode itemCode, int numberCheck)
    {
        int totalCount = ItemTotalCount(itemCode);
        return totalCount >= numberCheck;
    }
    protected virtual int ItemTotalCount(ItemCode itemCode)
    {
        int totalCount = 0;
        foreach (ItemInventory itemInventory in items)
        {
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            totalCount += itemInventory.itemCount;
        }
        return totalCount;
    }
    public virtual void DeductItem(ItemCode itemCode, int deductCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = items.Count - 1; i >= 0; i--)
        {
            if (deductCount <= 0) break;
            itemInventory = items[i];
            if (itemInventory.itemProfile.itemCode != itemCode) continue;
            if (deductCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;
                deductCount -= itemInventory.itemCount;
            }
            else 
            {
                deduct = deductCount;
                deductCount = 0;
            }
            itemInventory.itemCount -= deduct;
        }
        ClearEmptySlot();
    }
    protected virtual void ClearEmptySlot() 
    {
        ItemInventory itemInventory;
        for (int i = 0; i < items.Count; i++)
        {
            itemInventory = items[i];
            if (itemInventory.itemCount == 0) items.RemoveAt(i);
        }
    }
}
