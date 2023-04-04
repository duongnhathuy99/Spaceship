using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ItemProfileSO",menuName = "SO/ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemType = ItemType.NoType;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public List<ItemRecipe> upgradeLevels;

    public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO itemProfile in profiles)
        {
            if (itemProfile.itemCode != itemCode) continue;
            return itemProfile;
        }
        return null;
    }
}
