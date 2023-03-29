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
        if (other.transform.parent == bulletCtrl.Shooter) return;
        //Debug.Log("co va cham");
        bulletCtrl.DamageSender.Send(other.transform);
        CreateImpactFX();
    }
    protected virtual void CreateImpactFX()
    {
        string fxName = GetImpactFX();

        Vector3 hitPos = transform.position;
        Quaternion hitRot = transform.rotation;
        Transform fxImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        fxImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.impactBullet;
    }
}
