using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InventoryAbstract
{
    [SerializeField] protected SphereCollider _sphereCollider;
    [SerializeField] protected Rigidbody _rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSphereCollider();
        LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if (_sphereCollider != null) return;
        _sphereCollider = transform.GetComponent<SphereCollider>();
        _sphereCollider.isTrigger = true;
        _sphereCollider.radius = 0.3f;
        Debug.Log(transform.name + ":Load SphereCollider ", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (_rigidbody != null) return;
        _rigidbody = transform.GetComponent<Rigidbody>();
        _rigidbody.useGravity = false;
        _rigidbody.isKinematic = true;
        Debug.Log(transform.name + ":Load Rigidbody ", gameObject);
    }

    protected void OnTriggerEnter(Collider other)
    {
        ItemPickupAble itemPickup = other.GetComponent<ItemPickupAble>();
        if (itemPickup == null) return;

        ItemCode itemCode = itemPickup.GetItemCode();
        if (inventory.AddItem(itemCode, 1))
        {
            itemPickup.Picked();
        }
        //Debug.Log(other.name);
        //Debug.Log(other.transform.parent.name);
    }
}
