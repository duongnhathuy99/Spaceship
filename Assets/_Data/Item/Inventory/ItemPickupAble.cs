using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupAble : ItemAbstract
{
    [SerializeField] protected SphereCollider _sphereCollider;

    public static ItemCode String2ItemCode(string itemName)
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

    private void OnMouseDown()
    {
        //Debug.Log(transform.parent.name);
        PlayerCtrl.Instance.PlayerPickup.ItemPickup(this);
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if (_sphereCollider != null) return;
        _sphereCollider = transform.GetComponent<SphereCollider>();
        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = 0.1f;
        Debug.Log(transform.name + ":Load SphereCollider ", gameObject);
    }
    public virtual ItemCode GetItemCode() 
    {
        return ItemPickupAble.String2ItemCode(transform.parent.name);
    }
    public virtual void Picked()
    {
        ItemCtrl.ItemDespawn.DespawnObject();
    }
}
