using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletImpact : BulletAbstract
{
    [Header("Buller Impact")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigid;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadSphereCollider();
        LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = transform.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.05f;
        Debug.Log(transform.name + ":Load SphereCollider ", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (rigid != null) return;
        rigid = transform.GetComponent<Rigidbody>();
        rigid.isKinematic = true;
        Debug.Log(transform.name + ":Load Rigidbody ", gameObject);
    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("co va cham");
        bulletCtrl.DamageSender.Send(other.transform);
    }
}
