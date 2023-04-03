using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : InventoryAbstract
{
    [Header("Item Upgrade")]
    [SerializeField] protected int maxLevel = 9;
    void Start()
    {
        Invoke(nameof(test), 5);
    }
    protected virtual void test() 
    {
        UpgaradeItem(0);
    }
    protected virtual bool UpgaradeItem(int itemIndex)
    {
        if (itemIndex >= inventory.Items.Count) return false;

        ItemInventory itemInventory = inventory.Items[itemIndex];
        if (itemInventory.itemCount < 1) return false;

        List<ItemRecipe> upgradeLevels = itemInventory.itemProfile.upgradeLevels;
        if (!ItemUpgradeAble(upgradeLevels)) return false;
        if (!HaveEnoughIngredients(upgradeLevels, itemInventory.upgradeLevel)) return false;
        DeductIngredients(upgradeLevels, itemInventory.upgradeLevel);
        itemInventory.upgradeLevel++;
        return true;
    }

    protected virtual bool ItemUpgradeAble(List<ItemRecipe> upgradeLevels)
    {
        if (upgradeLevels.Count == 0) return false;
        return true;
    }

    protected virtual bool HaveEnoughIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;
        if (currentLevel > upgradeLevels.Count)
        {
            Debug.LogError("Item cant upgrade anymore, current:" + currentLevel);
            return false;
        }
        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            if (!inventory.ItemCheck(itemCode, itemCount)) return false;
        }
        return true;
    }
    protected virtual void DeductIngredients(List<ItemRecipe> upgradeLevels, int currentLevel)
    {
        ItemCode itemCode;
        int itemCount;

        ItemRecipe currentRecipeLevel = upgradeLevels[currentLevel];
        foreach (ItemRecipeIngredient ingredient in currentRecipeLevel.ingredients)
        {
            itemCode = ingredient.itemProfile.itemCode;
            itemCount = ingredient.itemCount;

            inventory.DeductItem(itemCode, itemCount);
        }
    }
}
