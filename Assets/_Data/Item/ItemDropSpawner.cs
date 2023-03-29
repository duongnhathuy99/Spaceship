using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner _instance;
    public static ItemDropSpawner Instance { get => _instance; }

   
    protected override void Awake()
    {
        base.Awake();
        if (_instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    public virtual void Drop(List<DropRate> dropList, Vector3 pos, Quaternion rot)
    {
        ItemCore itemCore = dropList[0].itemSO.itemCore;
        Transform itemDrop = Spawn(itemCore.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }
}
