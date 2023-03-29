using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item",menuName ="SO/Item")]
public class ItemSO : ScriptableObject
{
    public ItemCore itemCore = 0;
    public string itemName = "Item";
}
