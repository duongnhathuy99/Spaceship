using System;
using UnityEngine;
public enum ItemCode
{
   NoItem = 0,
   IronOre = 1,
   SilvelOre = 2,
   GoldOre = 3,
   IronSword = 100,
}

public class ItemCodeParser 
{
    public static ItemCode FromString(string itemName) 
    {
        try 
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }
}