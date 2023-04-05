using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : SaiMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;
    void Update()
    {
        IsShooting();
    }
    private void FixedUpdate()
    {
        Shooting(); 
       
    }
    protected virtual void Shooting() 
    {
        this.shootTimer += Time.fixedDeltaTime;
        if (!isShooting) return;
        if (shootTimer < shootDelay) return;
        shootTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.Spawn(BulletSpawner.bulletOne, spawnPos, rotation);
        if (newBullet == null) return;
        newBullet.gameObject.SetActive(true);
        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
        //Debug.Log("Shooting");
    }
    protected abstract bool IsShooting();
}
