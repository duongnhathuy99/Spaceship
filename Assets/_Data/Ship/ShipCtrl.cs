using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    [Header("Ship")]
    [SerializeField] protected Inventory inventory; 
    public Inventory Inventory { get => inventory; }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (inventory != null) return;
        inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ":Load Inventory ", gameObject);
    }
}
